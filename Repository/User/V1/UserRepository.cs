using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Repository.User.V1
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor _httpContextAccess;
        public UserRepository(IConfiguration _configuration, IHttpContextAccessor httpContextAccess)
        {
            configuration = _configuration;
            _httpContextAccess = httpContextAccess;
        }
        public UserModel AddUser(UserRequestModel userRequestModel)
        {

            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @UserName = userRequestModel.UserName,
                @Email = userRequestModel.Email,
                @PasswordHash = userRequestModel.PasswordHash,
                @RoleID = userRequestModel.RoleID,
                @IsActive = userRequestModel.IsActive,
                @CreatedBy = userRequestModel.CreatedBy,
                @ModifiedBy = userRequestModel.ModifiedBy,
                @DeletedBy = userRequestModel.DeletedBy
            };
            var customerModel = base.GetSPResults<UserModel>("cit.spCustomer", paramObjects);
            return customerModel.FirstOrDefault() ?? new UserModel();
        }

        public IEnumerable<UserModel> GetAllUser()
        {

            object paramObjects = new
            {
                @Flag = "A"
            };
            List<UserModel> users = base.GetSPResults<UserModel>("cit.spUserMaster", paramObjects);
            return users;

        }

        public UserModel GetUser(int UserId)
        {
            object paramObjects = new
            {
                @Flag = "R",
                UserID = UserId
            };
            var userModel = base.GetSPResults<UserModel>("cit.spUserMaster", paramObjects);
            return userModel.FirstOrDefault() ?? new UserModel();
        }

        public UserModel UpdateUser(UserRequestModel userModel)
        {
            object paramObjects = new
            {
                @Flag = "U",
                @UserID = userModel.UserID,
                @UserName = userModel.UserName,
                @Email = userModel.Email,
                @PasswordHash = userModel.PasswordHash,
                @RoleID = userModel.RoleID,
                @IsActive = userModel.IsActive,
                @ModifiedBy = userModel.ModifiedBy
            };
            var updateuserModel = base.GetSPResults<UserModel>("cit.spUserMaster", paramObjects);
            return updateuserModel.FirstOrDefault() ?? new UserModel();
        }

        public UserModel DeleteUser(int userid, int deletedBy)
        {
            object paramObjects = new
            {
                @Flag = "D",
                @userid = userid,
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<UserModel>("cit.spUserMaster", paramObjects);
            return result.FirstOrDefault() ?? new UserModel();
        }

        //[AllowAnonymous]

        string IUserRepository.GetUserID(string Username)
        {
            Username = _httpContextAccess.HttpContext.User.Identity.Name;
            if(Username == null) 
            {
                return null;
            }

            var currentUserName = _httpContextAccess.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            return Username;
        }
        string IUserRepository.GenerateAccessToken(string Username, string EmailAddress)
        {
            Username = "Sunil Kumar Patel";
            EmailAddress = "sunilpatel12221@gmail.com";
            var Securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, Username),
        new Claim(JwtRegisteredClaimNames.Email, EmailAddress),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

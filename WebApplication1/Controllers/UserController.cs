using Component;
using ApiVersionV1 = ForgoAPI.Services.User.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.RequestModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Forgo.Task.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Forgo.Task.Controllers
{
    [CITFilter]
    [ApiController]
    [Route("api/UserAPI")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly ApiVersionV1.IUserService _userService;
        private readonly IConfiguration configuration;
        public UserController(ApiVersionV1.IUserService userService, IConfiguration _configuration)
        {
            _userService = userService;
            configuration = _configuration;
        }

        [HttpGet]
        [Route("api/GetUserAPI")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                string AccessToken = "";
                UserModel userModel = new UserModel();
                userModel = _userService.GetUser(userId);
                if (userModel != null)
                {
                     AccessToken = _userService.GenerateAccessToken(userModel.UserName, userModel.Email);
                }            
                userModel.AccessToken = AccessToken;
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/GetAllUsersAPI")]
        public IActionResult GetAllUsers()
        {
            try
            {
                CommonResponse<UserModel> customerModels = new CommonResponse<UserModel>();

                customerModels = _userService.GetAllUser();

                return Ok(customerModels);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }
        [HttpPost]
        [Route("api/AddUserAPI")]

        public IActionResult AddUser(UserRequestModel userRequestModel)
        {
            try
            {
                UserModel userModel = new UserModel();
                if (ModelState.IsValid)
                {
                    if (userRequestModel.Version == APIVersions.Version2)
                    {
                        userModel = _userService.AddUser(userRequestModel);
                    }
                    else
                    {
                        userModel = _userService.AddUser(userRequestModel);
                    }
                }
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }
      
        [HttpPut]
        [Route("api/UpdateUserAPI")]
        public IActionResult UpdateUser(UserRequestModel userRequestModel)
        {
            try
            {
                UserModel userModel = new UserModel();
                if (ModelState.IsValid)
                {
                    userModel = _userService.UpdateUser(userRequestModel);
                }
                return Ok(userModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete]
        [Route("api/DeleteUserAPI")]

        public IActionResult DeleteUser(int userId, int deletedBy)
        {
            try
            {
                UserModel userModel = new UserModel();
                userModel = _userService.DeleteUser(userId, deletedBy);
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }
    }
}

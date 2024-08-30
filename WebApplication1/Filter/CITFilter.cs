using ForgoAPI.Entity.Item.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Repository.User.V1;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace Forgo.Task.Filter
{
    public class CITFilter : Attribute, IAuthorizationFilter // ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {          
            var IsAuthentication = context.HttpContext.User.Identity.IsAuthenticated;
            bool retVal = false;
            int userId = 2;
            var LoginRepo = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();

            string UserIds = LoginRepo.GetUserID("");

            UserModel _userModel = new UserModel();
            _userModel = LoginRepo.GetUser(userId);

            if (_userModel.UserID != 0)
            {
                retVal=true;
                //string AccessToken = LoginRepo.GenerateAccessToken();

                //var tokenHandler = new JwtSecurityTokenHandler();
                //var jwtToken = tokenHandler.ReadJwtToken(AccessToken);

                //if (jwtToken.ValidTo < DateTime.UtcNow)
                //{
                //    // Token has expired
                //    // Handle accordingly
                //}
            }
            else
            {
                HttpStatusCode status = HttpStatusCode.BadRequest;
                string message = "Unauthorizaed User Access";
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = (int)status;
                response.ContentType = "application/json";
                response.WriteAsync(message);
                context.Result = new ForbidResult();
            }
        }
    }
}

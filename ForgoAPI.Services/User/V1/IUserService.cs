using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.User.V1
{
    public interface IUserService
    {
        CommonResponse<UserModel> GetAllUser();
        UserModel AddUser(UserRequestModel userRequestModel);
        UserModel GetUser(int userId);
        UserModel UpdateUser(UserRequestModel userRequestModel);
        UserModel DeleteUser(int customerId, int deletedBy);
        string GenerateAccessToken(string Username, string EmailAddress);
    }
}

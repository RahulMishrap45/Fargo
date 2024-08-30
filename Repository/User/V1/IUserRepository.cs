using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.User.V1
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAllUser();
        UserModel AddUser(UserRequestModel userRequestModel);
        UserModel GetUser(int userId);
        UserModel UpdateUser(UserRequestModel userRequestModel);
        UserModel DeleteUser(int userId, int deletedBy);
        string GenerateAccessToken(string Username, string EmailAddress);
        string GetUserID(string Username);
    }
}

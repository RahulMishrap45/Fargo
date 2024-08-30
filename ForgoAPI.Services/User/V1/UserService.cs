using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using ForgoAPI.Services.Customer.V1;
using Repository.Customer.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.User.V1;

namespace ForgoAPI.Services.User.V1
{
    public class UserService : BaseService, IUserService
    {
        private IUserRepository _userService;

        public UserService(IUserRepository UserService)
        {
            _userService = UserService;
        }

        public UserModel AddUser(UserRequestModel userRequestModel)
        {
            return _userService.AddUser(userRequestModel);
        }

        public UserModel DeleteUser(int UserId, int deletedBy)
        {
            return _userService.DeleteUser(UserId, deletedBy);
        }

        public string GenerateAccessToken(string Username, string EmailAddress)
        {
            return _userService.GenerateAccessToken(Username, Username);
        }

        public CommonResponse<UserModel> GetAllUser()
        {
            var userList = _userService.GetAllUser().ToList();
            if (userList == null)
                return new CommonResponse<UserModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<UserModel>
            {
                Model = userList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
        }

        public UserModel GetUser(int userId)
        {
            return _userService.GetUser(userId);
        }

        public UserModel UpdateUser(UserRequestModel userRequestModel)
        {
            return _userService.UpdateUser(userRequestModel);
        }
    }
}

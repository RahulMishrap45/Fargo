using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Services.Customer.V1;
using Repository.Customer.V1;
using Repository.CustomerBranch.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.CustomerBranch.V1
{
    public class CustomerBranchService : BaseService, ICustomerBranchService
    {
        private ICustomerBranchRepository _customerbranchRepository;

        public CustomerBranchService(ICustomerBranchRepository customerbranchRepository)
        {
            _customerbranchRepository = customerbranchRepository;
        }

        public CustomerBranchModel AddCustomerbranch(CustomerBranchRequestModel customerbranchRequestModel)
        {
            return _customerbranchRepository.AddCustomerBranch(customerbranchRequestModel);
        }

        public CustomerBranchModel DeleteCustomerbranch(int CustomerBranchID, int deletedBy)
        {
            return _customerbranchRepository.DeleteCustomerBranch(CustomerBranchID, deletedBy);
        }

        public CommonResponse<CustomerBranchModel> GetAllCustomerbranch()
        {
            var customerbranchList = _customerbranchRepository.GetAllCustomerBranch().ToList();
            if (customerbranchList == null)
                return new CommonResponse<CustomerBranchModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<CustomerBranchModel>
            {
                Model = customerbranchList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
        }

        public CustomerBranchModel GetCustomerbranch(int CustomerBranchID)
        {
            return _customerbranchRepository.GetCustomerBranch(CustomerBranchID);
        }

        public CustomerBranchModel UpdateCustomerbranch(CustomerBranchRequestModel customerbranchRequestModel)
        {
            return _customerbranchRepository.UpdateCustomerBranch(customerbranchRequestModel);
        }
    }
}

using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.CustomerBranch.V1
{
    public interface ICustomerBranchService
    {
        CommonResponse<CustomerBranchModel> GetAllCustomerbranch();
        CustomerBranchModel AddCustomerbranch(CustomerBranchRequestModel customerbranchRequestModel);
        CustomerBranchModel GetCustomerbranch(int CustomerBranchID);
        CustomerBranchModel UpdateCustomerbranch(CustomerBranchRequestModel customerbranchRequestModel);
        CustomerBranchModel DeleteCustomerbranch(int CustomerBranchID, int deletedBy);
    }
}

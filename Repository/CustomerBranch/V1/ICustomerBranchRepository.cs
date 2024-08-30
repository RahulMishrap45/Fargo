using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerBranch.V1
{
    public interface ICustomerBranchRepository
    {
        IEnumerable<CustomerBranchModel> GetAllCustomerBranch();
        CustomerBranchModel AddCustomerBranch(CustomerBranchRequestModel regiomRequestModel);
        CustomerBranchModel GetCustomerBranch(int CustomerBranchID);
        CustomerBranchModel UpdateCustomerBranch(CustomerBranchRequestModel regiomRequestModel);
        CustomerBranchModel DeleteCustomerBranch(int CustomerBranchID, int deletedBy);
    }
}

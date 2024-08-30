using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Region.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerBranch.V1
{
    public class CustomerBranchRepository : BaseRepository, ICustomerBranchRepository
    {
        public CustomerBranchModel AddCustomerBranch(CustomerBranchRequestModel customerBranchRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @CustomerID = customerBranchRequestModel.CustomerID,
                @BranchID = customerBranchRequestModel.BranchID,
                @DataSource = customerBranchRequestModel.DataSource,
                @IsActive = customerBranchRequestModel.IsActive,
                @CreatedBy = customerBranchRequestModel.CreatedBy,
            };
            var customerBranchModel = base.GetSPResults<CustomerBranchModel>("cit.spCustomer", paramObjects);
            return customerBranchModel.FirstOrDefault() ?? new CustomerBranchModel();
        }

        public CustomerBranchModel DeleteCustomerBranch(int CustomerBranchID, int deletedBy)
        {
            object paramObjects = new
            {
                @CustomerBranchID = CustomerBranchID,
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<CustomerBranchModel>("cit.spDeleteCustomer", paramObjects);
            return result.FirstOrDefault() ?? new CustomerBranchModel();
        }

        public IEnumerable<CustomerBranchModel> GetAllCustomerBranch()
        {
            object paramObjects = new { };
            List<CustomerBranchModel> RegionType = base.GetSPResults<CustomerBranchModel>("cit.spGetAllCustomers", paramObjects);
            return RegionType;
        }

        public CustomerBranchModel GetCustomerBranch(int CustomerBranchID)
        {
            object paramObjects = new
            {
                @CustomerBranchID = CustomerBranchID
            };
            var customerBranchModel = base.GetSPResults<CustomerBranchModel>("cit.spGetCustomer", paramObjects);
            return customerBranchModel.FirstOrDefault() ?? new CustomerBranchModel();

        }

        public CustomerBranchModel UpdateCustomerBranch(CustomerBranchRequestModel customerbranchRequestModel)
        {
            object paramObjects = new
            {
                @CustomerBranchID = customerbranchRequestModel.CustomerBranchID,
                @CustomerID = customerbranchRequestModel.CustomerID,
                @BranchID = customerbranchRequestModel.BranchID,
                @DataSource = customerbranchRequestModel.DataSource,
                @ModifiedBy = customerbranchRequestModel.ModifiedBy,
                @IsActive = customerbranchRequestModel.IsActive,
            };
            var customerBranchModel = base.GetSPResults<CustomerBranchModel>("cit.spUpdateCustomer", paramObjects);
            return customerBranchModel.FirstOrDefault() ?? new CustomerBranchModel();
        }
    }
}

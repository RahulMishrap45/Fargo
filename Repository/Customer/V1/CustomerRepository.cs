using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Customer.V1
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerModel AddCustomer(CustomerRequestModel customerRequestModel)
        {

            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @CustomerName = customerRequestModel.CustomerName,
                @Address = customerRequestModel.Address,
                @ContactNumber = customerRequestModel.ContactNumber,
                @Email = customerRequestModel.Email,
                @DataSource = customerRequestModel.DataSource,
                @IsActive = customerRequestModel.IsActive,
                @CreatedBy = customerRequestModel.CreatedBy,
                @ModifiedBy = customerRequestModel.ModifiedBy,
                @DeletedBy = customerRequestModel.DeletedBy
            };
            var customerModel = base.GetSPResults<CustomerModel>("cit.spCustomer", paramObjects);
            return customerModel.FirstOrDefault() ?? new CustomerModel();
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {

            object paramObjects = new
            {
                @flag = "CR",
            };
            List<CustomerModel> customers = base.GetSPResults<CustomerModel>("cit.spGetAllCustomers", paramObjects);
            return customers;

        }

        public CustomerModel GetCustomer(int id)
        {
            object paramObjects = new
            {
                @CustomerID = id
            };
            var customerModel = base.GetSPResults<CustomerModel>("cit.spGetCustomer", paramObjects);
            return customerModel.FirstOrDefault() ?? new CustomerModel();
        }

        public CustomerModel UpdateCustomer(CustomerRequestModel customerModel)
        {
            object paramObjects = new
            {
                @CustomerID = customerModel.CustomerId,
                @CustomerName = customerModel.CustomerName,
                @Address = customerModel.Address,
                @ContactNumber = customerModel.ContactNumber,
                @Email = customerModel.Email,
                @IsActive = customerModel.IsActive,
                @ModifiedBy = customerModel.ModifiedBy
            };
            var updatedCustomerModel = base.GetSPResults<CustomerModel>("cit.spUpdateCustomer", paramObjects);
            return updatedCustomerModel.FirstOrDefault() ?? new CustomerModel();
        }

        public CustomerModel DeleteCustomer(int id, int deletedBy)
        {
            object paramObjects = new
            {
                @CustomerID = id,
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<CustomerModel>("cit.spDeleteCustomer", paramObjects);
            return result.FirstOrDefault() ?? new CustomerModel();
        }



    }
}

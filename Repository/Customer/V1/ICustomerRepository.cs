using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Customer.V1
{
    
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        CustomerModel AddCustomer(CustomerRequestModel customerRequestModel);
        CustomerModel GetCustomer(int customerId);
        CustomerModel UpdateCustomer(CustomerRequestModel customerRequestModel);
        CustomerModel DeleteCustomer(int customerId, int deletedBy);
    }
}

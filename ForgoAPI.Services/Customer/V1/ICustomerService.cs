using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Customer.V1
{
    public interface ICustomerService
    {
        CommonResponse<CustomerModel> GetAllCustomers();
        CustomerModel AddCustomer(CustomerRequestModel customerRequestModel);
        CustomerModel GetCustomer(int customerId);
        CustomerModel UpdateCustomer(CustomerRequestModel customerRequestModel);    
        CustomerModel DeleteCustomer(int customerId, int deletedBy);
    }
}

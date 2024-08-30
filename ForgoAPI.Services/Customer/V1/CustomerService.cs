using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Customer.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Customer.V1
{
    public class CustomerService : BaseService, ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CommonResponse<CustomerModel> GetAllCustomers()
        {
            var customerList = _customerRepository.GetAllCustomers().ToList();
            if (customerList == null)
                return new CommonResponse<CustomerModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<CustomerModel>
            {
                Model = customerList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
        }

        public CustomerModel AddCustomer(CustomerRequestModel customerRequestModel)
        {
            return _customerRepository.AddCustomer(customerRequestModel);
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return _customerRepository.GetCustomer(customerId);

        }

        public CustomerModel UpdateCustomer(CustomerRequestModel customerRequestModel)
        {
            return _customerRepository.UpdateCustomer(customerRequestModel);
        }

        public CustomerModel DeleteCustomer(int customerId, int deletedBy)
        {
            return _customerRepository.DeleteCustomer(customerId, deletedBy);
        }


    }
}

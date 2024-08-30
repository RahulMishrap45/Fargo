using Component;
using ApiVersionV1 = ForgoAPI.Services.Customer.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/CustomerControllerAPI")]
    public class CustomerController : BaseController
    {
        private readonly ApiVersionV1.ICustomerService _customerService;

        public CustomerController(ApiVersionV1.ICustomerService customerService) 
        { 
            _customerService= customerService;
        }
        [HttpGet]
        [Route("api/GetAllCustomersAPI")]

        public IActionResult GetAllCustomers() {
            try
            {
                CommonResponse<CustomerModel> customerModels = new CommonResponse<CustomerModel>();

               customerModels = _customerService.GetAllCustomers();

                return Ok(customerModels);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }
      
        [HttpPost]
        [Route("api/AddCustomerAPI")]

        public IActionResult AddCustomer(CustomerRequestModel customerRequestModel)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                if (ModelState.IsValid)
                {
                    if (customerRequestModel.Version == APIVersions.Version2)
                    {
                        customerModel = _customerService.AddCustomer(customerRequestModel);
                    }
                    else
                    {
                        customerModel = _customerService.AddCustomer(customerRequestModel);
                    }
                }
                return Ok(customerModel);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/GetCustomerAPI")]

        public IActionResult GetCustomer([FromRoute(Name = "customerId")] int customerId)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel = _customerService.GetCustomer(customerId);
                return Ok(customerModel);
            }
            catch (Exception ex) {
                return Problem(ex.Message, ex.StackTrace);
                
            }

        }

        [HttpPut]
        [Route("api/UpdateProductAPI")]

        public IActionResult UpdateProduct(CustomerRequestModel customerRequestModel) {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                if (ModelState.IsValid)
                {
                    customerModel = _customerService.UpdateCustomer(customerRequestModel);

                }
                return Ok(customerModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete]
        [Route("api/DeleteCustomerAPI")]

        public IActionResult DeleteCustomer(int customerId, int deletedBy) 
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel = _customerService.DeleteCustomer(customerId, deletedBy); 
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }

    }
}

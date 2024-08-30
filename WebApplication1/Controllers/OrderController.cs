using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Component;
using ApiVersionV1 = ForgoAPI.Services.OrderType.V1;
using ApiVersionV2 = ForgoAPI.Services.Customer.V1;
using ApiVersionV3 = ForgoAPI.Services.Order.V1;
using ForgoAPI.Services.Customer.V1;
using ForgoAPI.Entity.Item.RequestModels;
using Forgo.Task.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Forgo.Task.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[CITFilter]
    [ApiController]
    [Route("api/OrderAPI")]
    public class OrderController : ControllerBase
    {
        private readonly ApiVersionV1.IOrderTypeService _ordertypeService;
        private readonly ApiVersionV2.ICustomerService _customerService;
        private readonly ApiVersionV3.IOrderService _orderservice;

        public OrderController(ApiVersionV1.IOrderTypeService ordertypeService, ApiVersionV2.ICustomerService customerService, ApiVersionV3.IOrderService orderservice)
        {
            _ordertypeService = ordertypeService;
            _customerService = customerService;
            _orderservice = orderservice;
        }
        [HttpGet]

        [Route("api/GetAllordertypeAPI")]
        public IActionResult GetAllordertype()
        {
            try
            {
                CommonResponse<OrderTypeModel> ordertypeModels = new CommonResponse<OrderTypeModel>();
                ordertypeModels = _ordertypeService.GetAllordertype();
                return Ok(ordertypeModels);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/GetAllCustomersAPI")]
        public IActionResult GetAllCustomers()
        {
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
        [HttpGet]
        [Route("api/GetAllRouteAPI")]
        public IActionResult GetAllRoute(int customerId)
        {
            try
            {
                CommonResponse<RouteMaster> routeMaster = new CommonResponse<RouteMaster>();
                routeMaster = _orderservice.GetRoutelist(customerId);

                return Ok(routeMaster);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }
        [HttpPost]
        [Route("api/CreateOrderAPI")]
        public IActionResult CreateOrder(OrderRequestModel orderrequestModel)
        {
            try
            {
                OrderModel orderModel = new OrderModel();
                if (ModelState.IsValid)
                {
                    orderModel = _orderservice.CreateOrder(orderrequestModel);

                }
                return Ok(orderModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }
        //[HttpPost]
        //[Route("api/CreateTaskAPI")]
        //public IActionResult CreateTask(TaskRequestModel taskrequestmodel)
        //{
        //    try
        //    {
        //        TaskModel taskModel = new TaskModel();
        //        if (ModelState.IsValid)
        //        {
        //            taskModel = _orderservice.CreateTask(taskrequestmodel);
        //        }
        //        return Ok(taskModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message, ex.StackTrace);
        //    }
        //}
        
    }
}

using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Component;
using ApiVersionV1 = ForgoAPI.Services.OrderType.V1;
using ForgoAPI.Entity.Item.RequestModels;
using Microsoft.AspNetCore.Authorization;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/OrderTypeAPI")]
    public class OrderTypeController : ControllerBase
    {
        private readonly ApiVersionV1.IOrderTypeService _ordertypeService;
        public OrderTypeController(ApiVersionV1.IOrderTypeService ordertypeService)
        {
            _ordertypeService = ordertypeService;
        }
        [HttpGet]
        [Route("api/GetAllOrderTypeAPI")]
        public IActionResult GetAllOrderType()
        {
            try
            {
                CommonResponse<OrderTypeModel> customerModels = new CommonResponse<OrderTypeModel>();

                customerModels = _ordertypeService.GetAllordertype();

                return Ok(customerModels);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/AddOrderTypeAPI")]
        public IActionResult AddOrderType(OrderTypeRequestModel OrdertypeRequestModel)
        {
            try
            {
                OrderTypeModel orderTypeModel = new OrderTypeModel();
                if (ModelState.IsValid)
                {
                    if (OrdertypeRequestModel.Version == APIVersions.Version2)
                    {
                        orderTypeModel = _ordertypeService.AddOrderType(OrdertypeRequestModel);
                    }
                    else
                    {
                        orderTypeModel = _ordertypeService.AddOrderType(OrdertypeRequestModel);
                    }
                }
                return Ok(orderTypeModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        [HttpGet]
        [Route("api/GetBranchAPI")]

        public IActionResult GetBranch([FromRoute(Name = "OrderTypeId")] int OrderTypeId)
        {
            try
            {
                OrderTypeModel ordertypeModel = new OrderTypeModel();
                ordertypeModel = _ordertypeService.GetOrderType(OrderTypeId);
                return Ok(ordertypeModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }

        }

        [HttpPut]
        [Route("api/UpdateBranchAPI")]

        public IActionResult UpdateBranch(OrderTypeRequestModel ordertypeRequestModel)
        {
            try
            {
                OrderTypeModel ordertypeModel = new OrderTypeModel();
                if (ModelState.IsValid)
                {
                    ordertypeModel = _ordertypeService.UpdateOrderType(ordertypeRequestModel);
                }
                return Ok(ordertypeModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete]
        [Route("apiDeleteBranchAPI")]

        public IActionResult DeleteBranch(int OrderTypeId, int deletedBy)
        {
            try
            {
                OrderTypeModel ordertypeModel = new OrderTypeModel();
                ordertypeModel = _ordertypeService.DeleteOrderType(OrderTypeId, deletedBy);
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }
    }
}

using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using ApiVersionV1 = ForgoAPI.Services.OrderDistribute.V1;
using Component;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.ResponseModels;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/OrderDistribute")]
    public class OrderDistributeController : ControllerBase
    {
        private readonly ApiVersionV1.IOrderDistributeService _orderDistributeService;

        public OrderDistributeController(ApiVersionV1.IOrderDistributeService orderDistributeService)
        {
            _orderDistributeService = orderDistributeService;
        }

        [HttpGet]
        [Route("api/GetAllOrderDistributedAPI")]
        public IActionResult GetAllOrderDistributed()
        {
            try
            {
                CommonResponse<OrderDistributeModel> commonResponse = new CommonResponse<OrderDistributeModel>();

                commonResponse = _orderDistributeService.GetOrderDistribute();

                return Ok(commonResponse);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/AddOrderDistributeAPI")]
        public IActionResult AddOrderDistribute(OrderDistributeRequestModel orderDistributeRequestModel)
        {
            try
            {
                OrderDistributeRequestModel orderDistributeModel = new OrderDistributeRequestModel();
                if (ModelState.IsValid)
                {
                    if (orderDistributeRequestModel.Version == APIVersions.Version2)
                    {
                        orderDistributeModel = _orderDistributeService.AddOrderDistribute(orderDistributeRequestModel);
                    }
                    else
                    {
                        orderDistributeModel = _orderDistributeService.AddOrderDistribute(orderDistributeRequestModel);
                    }
                }
                return Ok(orderDistributeModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        [HttpGet]
        [Route("api/GetAllTaskGroupAPI")]
        public IActionResult GetAllTaskGroupAPI()
        {
            try
            {
                CommonResponse<TaskGroupModel> commonResponse = new CommonResponse<TaskGroupModel>();

                commonResponse = _orderDistributeService.GetTaskGroup();

                return Ok(commonResponse);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/AddTaskGroupAPI")]
        public IActionResult AddTaskGroupAPI(TaskGroupRequestModel taskGroupRequestModel)
        {
            try
            {
                TaskGroupRequestModel taskGroup = new TaskGroupRequestModel();
                if (ModelState.IsValid)
                {
                    if (taskGroupRequestModel.Version == APIVersions.Version2)
                    {
                        taskGroup = _orderDistributeService.AddTaskGroup(taskGroupRequestModel);
                    }
                    else
                    {
                        taskGroup = _orderDistributeService.AddTaskGroup(taskGroupRequestModel);
                    }
                }
                return Ok(taskGroup);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        [HttpPut]
        [Route("api/UpdateTaskGroupAPI")]
        public IActionResult UpdateTaskGroup(TaskGroupModel taskGroupModel)
        {
            try
            {
                TaskGroupModel taskGroup = new TaskGroupModel();
                if (ModelState.IsValid)
                {
                    taskGroup = _orderDistributeService.UpdateTaskGroup(taskGroupModel);
                }
                return Ok(taskGroupModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete]
        [Route("api/DeleteTaskGroupAPI")]
        public IActionResult DeleteTaskGroup(int id)
        {
            try
            {
                TaskGroupModel taskGroupModel = new TaskGroupModel();
                taskGroupModel = _orderDistributeService.DeleteTaskGroup(id);
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }
    }
}

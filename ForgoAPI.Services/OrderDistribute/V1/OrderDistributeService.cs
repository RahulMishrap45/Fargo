using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.ResponseModels;
using Repository.Branch.V1;
using Repository.OrderDistribute.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.OrderDistribute.V1
{
    public class OrderDistributeService : BaseService, IOrderDistributeService
    {
        private readonly IOrderDistributeRepository _orderDistributeRepository;

        public OrderDistributeService(IOrderDistributeRepository orderDistributeRepository)
        {
            _orderDistributeRepository = orderDistributeRepository;
        }

        public CommonResponse<OrderDistributeModel> GetOrderDistribute()
        {
            var orderDistributeList = _orderDistributeRepository.GetOrderDistribute().ToList();
            if (orderDistributeList == null)
                return new CommonResponse<OrderDistributeModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<OrderDistributeModel>
            {
                Model = orderDistributeList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };

        }

        public OrderDistributeRequestModel AddOrderDistribute(OrderDistributeRequestModel orderDistributeRequestModel)
        {
            return _orderDistributeRepository.AddOrderDistribute(orderDistributeRequestModel);
        }

        public CommonResponse<TaskGroupModel> GetTaskGroup()
        {
            var taskGroupList = _orderDistributeRepository.GetTaskGroup().ToList();
            if (taskGroupList == null)
                return new CommonResponse<TaskGroupModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<TaskGroupModel>
            {
                Model = taskGroupList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };

        }

        public TaskGroupRequestModel AddTaskGroup(TaskGroupRequestModel taskGroupModel)
        {
            return _orderDistributeRepository.AddTaskGroup(taskGroupModel);
        }

        public TaskGroupModel UpdateTaskGroup(TaskGroupModel taskGroupModel)
        {
            return _orderDistributeRepository.UpdateTaskGroup(taskGroupModel);
        }

        public TaskGroupModel DeleteTaskGroup(int id)
        {
            return _orderDistributeRepository.DeleteTaskGroup(id);
        }
    }
}

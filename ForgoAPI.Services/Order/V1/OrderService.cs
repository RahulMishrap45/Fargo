using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Services.Order.V1;
using Repository.Customer.V1;
using Repository.Order.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Order.V1
{
    public class OrderService : BaseService, IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderModel CreateOrder(OrderRequestModel orderRequestModel)
        {
            return _orderRepository.CreateOrder(orderRequestModel);
        }

        //public TaskModel CreateTask(TaskRequestModel taskRequestModel)
        //{
        //    return _orderRepository.CreateTask(taskRequestModel);
        //}

        public CommonResponse<RouteMaster> GetRoutelist(int customerId)
        {
            var routeList = _orderRepository.GetRoutelist(customerId);
            if (routeList == null)
                return new CommonResponse<RouteMaster>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<RouteMaster>
            {
                Model = (List<RouteMaster>)routeList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
            // return _orderRepository.GetRoutelist(customerId);
        }
    }
}

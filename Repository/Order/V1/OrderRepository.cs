using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Order.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Order.V1
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderModel CreateOrder(OrderRequestModel orderRequestModel)
        {
            int Res = 0;
            object paramObjects = new
            {
                @flag = "4",
                @OrderTypeId = orderRequestModel.OrderTypeId,
                @CustomerId = orderRequestModel.CustomerId,
                @UserRegionID = 1,
                @RouteID = orderRequestModel.RouteID,
                @IsVault = orderRequestModel.IsVault,
                @IsFullDayOccupancy = orderRequestModel.FullDayOccupancy,
                @RepeatFrequency = orderRequestModel.Repeats,
                @Priority = orderRequestModel.PriorityId,
                @IsVaultFinal = orderRequestModel.IsVaultFinal,
                @StartDate = orderRequestModel.StartDate,
                @StartTime = orderRequestModel.StartTime,
                @EndTime = orderRequestModel.EndTime,
                @EndTask = orderRequestModel.EndTask,
                @RepeatIn = orderRequestModel.RepeatIn,
                @CreatedBy = orderRequestModel.CreatedBy,
            };

            var orderModel = base.GetSPResults<OrderModel>("cit.usp_Order", paramObjects);

            int tskboj = AddTask(orderRequestModel.TaskModellist, orderModel[0].OrderId);

            return orderModel.FirstOrDefault() ?? new OrderModel();
        }

        public int AddTask(List<TaskModel> taskModellist, int OrderId)
        {
            int res = 0;
            foreach (var taskobj in taskModellist)
            {
                object paramObjects = new
                {

                    @flag = "5",
                    @OrderID = OrderId,
                    @TaskType = taskobj.TaskType,
                    @PickUpLocation = taskobj.PickUpLocation,
                    @DeliveryLocation = taskobj.DeliveryLocation,
                    @TaskSequence = taskobj.TaskSequence,
                    @IsRecurring = taskobj.IsRecurring,
                    @DataSource = taskobj.DataSource,
                    @PickupType = taskobj.PickupType,
                    @CreatedBy = taskobj.CreatedBy,
                };
                var taskmodel = base.GetSPResults<TaskModel>("cit.usp_Order", paramObjects);
            }
            return res = 0;
            // return taskmodel.FirstOrDefault() ?? new TaskModel();
        }

        public IEnumerable<RouteMaster> GetRoutelist(int customerId)
        {
            object paramObjects = new
            {
                @flag = "3",
                @CustomerID = customerId
            };
            List<RouteMaster> routeMaster = base.GetSPResults<RouteMaster>("cit.usp_Order", paramObjects);
            return routeMaster;

        }
    }
}

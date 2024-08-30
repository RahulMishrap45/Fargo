using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Order.V1
{
    public interface IOrderRepository
    {
        IEnumerable<RouteMaster> GetRoutelist(int customerId);
        OrderModel CreateOrder(OrderRequestModel orderRequestModel);
        //TaskModel CreateTask(TaskRequestModel orderRequestModel);
    }

}

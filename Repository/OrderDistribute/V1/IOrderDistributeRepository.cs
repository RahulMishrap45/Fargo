using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDistribute.V1
{
    public interface IOrderDistributeRepository
    {
        IEnumerable<OrderDistributeModel> GetOrderDistribute();
        IEnumerable<TaskGroupModel> GetTaskGroup();
        OrderDistributeRequestModel AddOrderDistribute(OrderDistributeRequestModel orderDistributeRequestModel);
        TaskGroupRequestModel AddTaskGroup(TaskGroupRequestModel taskGroupModel);
        TaskGroupModel UpdateTaskGroup(TaskGroupModel taskGroupModel);
        TaskGroupModel DeleteTaskGroup(int id);
    }
}

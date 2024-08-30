using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.OrderDistribute.V1
{
    public interface IOrderDistributeService
    {
        CommonResponse<OrderDistributeModel> GetOrderDistribute();
        CommonResponse<TaskGroupModel> GetTaskGroup();
        OrderDistributeRequestModel AddOrderDistribute(OrderDistributeRequestModel orderDistributeRequestModel);
        TaskGroupRequestModel AddTaskGroup(TaskGroupRequestModel taskGroupModel);
        TaskGroupModel UpdateTaskGroup(TaskGroupModel taskGroupModel);
        TaskGroupModel DeleteTaskGroup(int id);
    }
}

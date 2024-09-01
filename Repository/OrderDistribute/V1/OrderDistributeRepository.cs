using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity.Item.ResponseModels;
using Repository.Branch.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.OrderDistribute.V1
{
    public class OrderDistributeRepository : BaseRepository, IOrderDistributeRepository
    {
        public IEnumerable<OrderDistributeModel> GetOrderDistribute()
        {
            object paramObjects = new {
                Flag = strctCRUDAction.GetAll
            };
            List<OrderDistributeModel> orderDistribute = base.GetSPResults<OrderDistributeModel>("cit.proc_VehicleAssignment", paramObjects);
            return orderDistribute;
        }

        public OrderDistributeRequestModel AddOrderDistribute(OrderDistributeRequestModel orderDistributeRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @GroupId = orderDistributeRequestModel.GroupID,
                @VehicleID = orderDistributeRequestModel.VehicleID,
                @CrewCommanderID = orderDistributeRequestModel.CrewCommanderID,
                @PoliceID = orderDistributeRequestModel.PoliceID,
                @TaskID = orderDistributeRequestModel.TaskID
            };
            var OrderDistribute = base.GetSPResults<OrderDistributeRequestModel>("cit.proc_VehicleAssignment", paramObjects);
            return OrderDistribute.FirstOrDefault() ?? new OrderDistributeRequestModel();
        }

        public IEnumerable<TaskGroupModel> GetTaskGroup()
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.GetAll,
            };
            List<TaskGroupModel> taskGroup = base.GetSPResults<TaskGroupModel>("cit.spTaskGroup", paramObjects);
            return taskGroup;
        }

        public TaskGroupRequestModel AddTaskGroup(TaskGroupRequestModel taskGroupModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @GroupName = taskGroupModel.GroupName,
                @TaskId = taskGroupModel.TaskID,
                @TaskDate= DateTime.Now
            };
            var taskGroup = base.GetSPResults<TaskGroupRequestModel>("cit.spTaskGroup", paramObjects);
            return taskGroup.FirstOrDefault() ?? new TaskGroupRequestModel();
        }

        public TaskGroupModel UpdateTaskGroup(TaskGroupModel taskGroupModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Update,
                @ID = taskGroupModel.Id,
                @GroupName = taskGroupModel.GroupName,
                @TaskId = taskGroupModel.TaskId,
                @TaskDate = DateTime.Now
            };
            var UpdateTaskGroup = base.GetSPResults<TaskGroupModel>("cit.spTaskGroup", paramObjects);
            return UpdateTaskGroup.FirstOrDefault() ?? new TaskGroupModel();
        }

        public TaskGroupModel DeleteTaskGroup(int id)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Delete,
                @ID = id
            };
            var result = base.GetSPResults<TaskGroupModel>("cit.spTaskGroup", paramObjects);
            return result.FirstOrDefault() ?? new TaskGroupModel();
        }
    }
}



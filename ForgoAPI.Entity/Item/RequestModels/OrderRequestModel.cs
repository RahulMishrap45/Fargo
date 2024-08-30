using ForgoAPI.Entity.Item.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class OrderRequestModel : BaseRequest
    {
        public string OrderNumber { get; set; }
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int CustomerId { get; set; }
        public int RouteID { get; set; }
        public int PickUpLocation { get; set; }
        public string IsVault { get; set; }
        public string IsVaultFinal { get; set; }
        public bool FullDayOccupancy { get; set; }
        public int Repeats { get; set; }
        public int PriorityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime EndTask { get; set; }
        public string RepeatIn { get; set; }
        public List<TaskModel> TaskModellist { get; set; }
    }
}

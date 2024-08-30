using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.BusinessModels
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public int OrderID { get; set; }
        public string TaskType { get; set; }
        public int PickType { get; set; }
        public string PickUpLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public int TaskSequence { get; set; }
        public bool IsRecurring { get; set; }
        public string DataSource { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string PickupType { get; set; }
    }
}

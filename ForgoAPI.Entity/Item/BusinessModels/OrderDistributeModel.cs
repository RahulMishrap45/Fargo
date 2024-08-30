using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.BusinessModels
{
    public class OrderDistributeModel
    {
        public int? OrderID { get; set; }
        public string? OrderNumber { get; set; }
        public int? OrdertypeId { get; set; }
        public string? TypeName { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? TaskId { get; set; }
        public string? TaskType { get; set; }
        public int? RouteId { get; set; }
        public string? PickupLocation { get; set; }
        public string?  DeliveryLocation{ get; set; }
        public int? Distance { get; set; }
        //[JsonProperty("time_in_minutes")]
        public int? time_in_minutes { get; set; }
        public string? GroupName { get; set; }
        public int? LeadId { get; set; }
        public string? LeadCarName { get; set; }
        public int? ChaseId { get; set; }
        public string? ChaseCarName { get; set; }
        public int? CrewCommanderId { get; set; }
        //[JsonProperty("CommanderName")]
        public string CommanderName { get; set; }
        public DateTime TaskDate { get; set; }
    }
}

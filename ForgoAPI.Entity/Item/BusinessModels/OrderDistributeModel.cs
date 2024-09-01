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
        public int? TaskId { get; set; }
        public string? TaskName { get; set; }
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public int? LeadId { get; set; }
        public string? LeadCarName { get; set; }
        public int? ChaseId { get; set; }
        public string? ChaseCarName { get; set; }
        public int? CrewCommanderId { get; set; }
        public string CommanderName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class OrderDistributeRequestModel : BaseRequest
    {
        public int? GroupID { get; set; }
        public int? VehicleID { get; set; }
        public int? CrewCommanderID { get; set; }
        public int? PoliceID { get; set; }
        public int? TaskID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class OrderDistributeRequestModel : BaseRequest
    {
        public int? OrderID { get; set; }
        public int? OrderTypeID { get; set; }
        public int? CustomerID { get; set; }
        public int? TaskID { get; set; }
        public int? RouteID { get; set; }
        public int? LeadID { get; set; }
        public int? ChaseID { get; set; }
        public int? CrewCommanderID { get; set; }
    }
}

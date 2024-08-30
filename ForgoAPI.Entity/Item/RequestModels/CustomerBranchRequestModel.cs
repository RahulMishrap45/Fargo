using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class CustomerBranchRequestModel:BaseRequest
    {
        public int CustomerBranchID { get; set; }
        public int? CustomerID { get; set; }
        public int? BranchID { get; set; }
        public string? DataSource { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

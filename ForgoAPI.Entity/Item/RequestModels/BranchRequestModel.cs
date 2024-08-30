using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class BranchRequestModel : BaseRequest
    {
        public int? BranchID { get; set; }
        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? DataSource { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

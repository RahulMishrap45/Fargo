using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.BusinessModels
{
    public class OrderTypeModel
    {
        public int OrderTypeID { get; set; }
        public string? TypeName { get; set; }
        public string? DataSource { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeleteBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

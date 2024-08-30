using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.RequestModels
{
    public class TaskGroupRequestModel : BaseRequest
    {
        public string? GroupName { get; set; }
        public int TaskID { get; set; }
        public DateTime? TaskDate { get; set; } = DateTime.Now;
    }
}

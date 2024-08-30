using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.ResponseModels
{
    public class TaskGroupModel : BaseRequest
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public int TaskId { get; set; }
        public string? TaskDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity
{
    public class CommonResponse<T> : BaseResponse
    {
        public List<T>? Model { get; set; }
    }
}

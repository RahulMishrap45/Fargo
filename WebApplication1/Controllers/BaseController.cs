using Microsoft.AspNetCore.Mvc;

namespace Forgo.Task.Controllers
{
    public class BaseController : ControllerBase
    {
        public override ObjectResult Problem(string? detail = null, string? instance = null, int? statusCode = null, string? title = null, string? type = null)
        {
            return base.Problem(detail, instance, statusCode, title, type); 
        }

    }
}

using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI_DotNetMVC.Controllers
{
    public class BaseController : ApiController
    {
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

using System.Collections.Generic;
using System.Web.Http;


namespace WebAPI_DotNetMVC.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [ActionName("GetValues")]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ActionName("GetValues1")]
        [AllowAnonymous]
        // GET api/values/5
        public string Get(int id)
        {
            //db operations 

            return "value";
        }

        [AllowAnonymous]       
        [HttpGet]
        // GET api/values/5
        public string Get(string id)
        {
            return "With Auth > value";
        }

        [ActionName("WithFloat")]
        public string Get(float id)
        {
            return "value";
        }

        [HttpPost()]
        // POST api/values
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

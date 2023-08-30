using System.Web.Http;
using WebAPI_DotNetMVC.DBContext;

namespace WebAPI_DotNetMVC.Controllers
{
    public class AddressController : ApiController
    {
        public readonly DemoDBContext demoDBContext;
        public AddressController()
        {
            this.demoDBContext = new DemoDBContext();
        }

        [ActionName("AddAddress")]
        [HttpPost]
        public int Create(Address address)
        {
            this.demoDBContext.Addresses.Add(address);

            this.demoDBContext.SaveChanges();

            return address.Id;
        }
    }
}

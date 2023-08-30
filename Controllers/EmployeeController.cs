using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_DotNetMVC.DBContext;

namespace WebAPI_DotNetMVC.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {        
        public readonly EFDatabaseFirstEntities eFDatabaseFirstEntities;
        public EmployeeController()
        {
            this.eFDatabaseFirstEntities = new EFDatabaseFirstEntities();
        }

        [ActionName("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return this.eFDatabaseFirstEntities.Employees.ToList();
        }

        [ActionName("GetEmployeeDetails")]
        public async Task<Employee> Get(int id)
        {
            return await this.eFDatabaseFirstEntities.Employees.Where(x => x.Id == id).FirstAsync();
        }               
    }
}

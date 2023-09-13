using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_DotNetMVC.DBContext;
using WebAPI_DotNetMVC.Filters;
using WebAPI_DotNetMVC.Model;

namespace WebAPI_DotNetMVC.Controllers
{
    public class StudentController : ApiController
    {
        public readonly DemoDBContext demoDBContext;
        public StudentController()
        {
            demoDBContext = new DemoDBContext();
        }

        //[CustomAuthFilter]
        [Authorize]
        [CustomAuthFilter]
        [ActionName("GetStudents")]
        public IEnumerable<Student> Get()
        {
            return demoDBContext.Students.ToList();

            //var student = (from x in this.demoDBContext.Students
            //               join ad in this.demoDBContext.Addresses on x.Id equals ad.Id
            //               where x.Email == "nu@gmail.com"
            //               orderby x.Email descending
            //               select x);
            //return a;
        }


        [ActionName("GetStudentDetails")]
        public async Task<Student> Get(int id)
        {
            return await demoDBContext.Students.Where(x => x.Id == id).FirstAsync();
        }

        [ActionName("CreateStudent")]
        [HttpPost]
        public int Create(Student student)
        {
            //Student existingRecord = this.demoDBContext.Students.Where(x => x.Id == student.Id).FirstOrDefault();

            demoDBContext.Students.Add(student);

            // this.demoDBContext.Entry(existingRecord).CurrentValues.SetValues(student);

            demoDBContext.SaveChanges();

            return student.Id;
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
            // Method intentionally left empty.
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            // Method intentionally left empty.
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // Method intentionally left empty.
        }
    }
}

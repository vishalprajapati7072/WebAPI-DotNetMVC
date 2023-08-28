﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_DotNetMVC.DBContext;
using WebAPI_DotNetMVC.Model;

namespace WebAPI_DotNetMVC.Controllers
{
    public class ValuesController : ApiController
    {
        public readonly DemoDBContext demoDBContext;
        public ValuesController()
        {
            this.demoDBContext = new DemoDBContext();
        }


        [ActionName("GetStudents")]
        public IEnumerable<Student> Get()
        {
            return this.demoDBContext.Students.ToList();
        }

        [ActionName("GetStudentDetails")]
        public async Task<Student> Get(int id)
        {
            return await this.demoDBContext.Students.Where(x => x.Id == id).FirstAsync();
        }

        [ActionName("CreateStudent")]
        [HttpPost]
        public int Create(Student student)
        {
            Student existingRecord = this.demoDBContext.Students.Where(x => x.Id == student.Id).FirstOrDefault();

            this.demoDBContext.Students.Add(student);

            this.demoDBContext.Entry(existingRecord).CurrentValues.SetValues(student);

            this.demoDBContext.SaveChanges();

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

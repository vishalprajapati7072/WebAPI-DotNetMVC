using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_DotNetMVC.Model
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
            
        public string EmpName { get; set; }
    }
}
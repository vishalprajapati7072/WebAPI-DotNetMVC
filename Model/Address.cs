using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_DotNetMVC.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
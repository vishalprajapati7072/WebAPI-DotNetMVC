using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_DotNetMVC.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("first_name", TypeName = "varchar")]
        [StringLength(501)]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar")]
        [StringLength(50)]
        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
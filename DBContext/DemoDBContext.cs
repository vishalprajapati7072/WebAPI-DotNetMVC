using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAPI_DotNetMVC.Model;

namespace WebAPI_DotNetMVC.DBContext
{
    public class DemoDBContext: DbContext
    {
        public DemoDBContext() : base("DemoDBContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        //public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
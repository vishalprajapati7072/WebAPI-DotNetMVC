namespace WebAPI_DotNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployeetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
        }
    }
}

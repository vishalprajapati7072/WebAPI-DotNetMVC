namespace WebAPI_DotNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforignkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "StudentId", "dbo.Student");
            DropIndex("dbo.Address", new[] { "StudentId" });
            DropTable("dbo.Address");
        }
    }
}

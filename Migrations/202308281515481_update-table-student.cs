namespace WebAPI_DotNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablestudent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Student", name: "FirstName", newName: "first_name");
            AlterColumn("dbo.Student", "first_name", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "first_name", c => c.String());
            RenameColumn(table: "dbo.Student", name: "first_name", newName: "FirstName");
        }
    }
}

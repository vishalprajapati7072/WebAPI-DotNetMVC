namespace WebAPI_DotNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercolumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Student", name: "first_name", newName: "FirstName");
            RenameColumn(table: "dbo.Student", name: "LastName", newName: "last_name");
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Student", "last_name", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "last_name", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String(maxLength: 100, unicode: false));
            RenameColumn(table: "dbo.Student", name: "last_name", newName: "LastName");
            RenameColumn(table: "dbo.Student", name: "FirstName", newName: "first_name");
        }
    }
}

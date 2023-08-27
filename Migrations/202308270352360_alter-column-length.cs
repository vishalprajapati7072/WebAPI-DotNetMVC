namespace WebAPI_DotNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercolumnlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "last_name", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "last_name", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}

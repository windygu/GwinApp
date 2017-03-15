namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuItemApplications", "Code", c => c.String(maxLength: 65));
            CreateIndex("dbo.MenuItemApplications", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.MenuItemApplications", new[] { "Code" });
            AlterColumn("dbo.MenuItemApplications", "Code", c => c.String());
        }
    }
}

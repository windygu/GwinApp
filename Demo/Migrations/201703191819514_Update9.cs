namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authorizations", "Reference", c => c.String());
            AddColumn("dbo.Roles", "Reference", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Reference", c => c.String());
            AddColumn("dbo.Cities", "Reference", c => c.String());
            AddColumn("dbo.Countries", "Reference", c => c.String());
            AddColumn("dbo.ContactInformations", "Reference", c => c.String());
            AddColumn("dbo.TaskProjects", "Reference", c => c.String());
            AddColumn("dbo.Individuals", "Reference", c => c.String());
            AddColumn("dbo.Projects", "Reference", c => c.String());
            AddColumn("dbo.GwinActivities", "Reference", c => c.String());
            AddColumn("dbo.Users", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Reference");
            DropColumn("dbo.GwinActivities", "Reference");
            DropColumn("dbo.Projects", "Reference");
            DropColumn("dbo.Individuals", "Reference");
            DropColumn("dbo.TaskProjects", "Reference");
            DropColumn("dbo.ContactInformations", "Reference");
            DropColumn("dbo.Countries", "Reference");
            DropColumn("dbo.Cities", "Reference");
            DropColumn("dbo.MenuItemApplications", "Reference");
            DropColumn("dbo.Roles", "Reference");
            DropColumn("dbo.Authorizations", "Reference");
        }
    }
}

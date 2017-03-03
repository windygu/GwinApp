namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItemApplications", "Code", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Description_French", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Description_English", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Description_Arab", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Title_French", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Title_English", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Title_Arab", c => c.String());
            DropColumn("dbo.MenuItemApplications", "Name");
            DropColumn("dbo.MenuItemApplications", "Description");
            DropColumn("dbo.MenuItemApplications", "TitleArabic");
            DropColumn("dbo.MenuItemApplications", "TitleFrench");
            DropColumn("dbo.MenuItemApplications", "TitleEnglish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuItemApplications", "TitleEnglish", c => c.String());
            AddColumn("dbo.MenuItemApplications", "TitleFrench", c => c.String());
            AddColumn("dbo.MenuItemApplications", "TitleArabic", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Description", c => c.String());
            AddColumn("dbo.MenuItemApplications", "Name", c => c.String());
            DropColumn("dbo.MenuItemApplications", "Title_Arab");
            DropColumn("dbo.MenuItemApplications", "Title_English");
            DropColumn("dbo.MenuItemApplications", "Title_French");
            DropColumn("dbo.MenuItemApplications", "Description_Arab");
            DropColumn("dbo.MenuItemApplications", "Description_English");
            DropColumn("dbo.MenuItemApplications", "Description_French");
            DropColumn("dbo.MenuItemApplications", "Code");
        }
    }
}

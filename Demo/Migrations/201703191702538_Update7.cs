namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name_French", c => c.String());
            AddColumn("dbo.Roles", "Name_English", c => c.String());
            AddColumn("dbo.Roles", "Name_Arab", c => c.String());
            AddColumn("dbo.Roles", "Description_French", c => c.String());
            AddColumn("dbo.Roles", "Description_English", c => c.String());
            AddColumn("dbo.Roles", "Description_Arab", c => c.String());
            DropColumn("dbo.Roles", "Name");
            DropColumn("dbo.Roles", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Description", c => c.String());
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Roles", "Description_Arab");
            DropColumn("dbo.Roles", "Description_English");
            DropColumn("dbo.Roles", "Description_French");
            DropColumn("dbo.Roles", "Name_Arab");
            DropColumn("dbo.Roles", "Name_English");
            DropColumn("dbo.Roles", "Name_French");
        }
    }
}

namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "Name_French", c => c.String());
            AddColumn("dbo.Individuals", "Name_English", c => c.String());
            AddColumn("dbo.Individuals", "Name_Arab", c => c.String());
            AddColumn("dbo.Individuals", "FirstName_French", c => c.String());
            AddColumn("dbo.Individuals", "FirstName_English", c => c.String());
            AddColumn("dbo.Individuals", "FirstName_Arab", c => c.String());
            AddColumn("dbo.Users", "Name_French", c => c.String());
            AddColumn("dbo.Users", "Name_English", c => c.String());
            AddColumn("dbo.Users", "Name_Arab", c => c.String());
            AddColumn("dbo.Users", "FirstName_French", c => c.String());
            AddColumn("dbo.Users", "FirstName_English", c => c.String());
            AddColumn("dbo.Users", "FirstName_Arab", c => c.String());
            DropColumn("dbo.Individuals", "Name");
            DropColumn("dbo.Individuals", "FirstName");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Individuals", "FirstName", c => c.String());
            AddColumn("dbo.Individuals", "Name", c => c.String());
            DropColumn("dbo.Users", "FirstName_Arab");
            DropColumn("dbo.Users", "FirstName_English");
            DropColumn("dbo.Users", "FirstName_French");
            DropColumn("dbo.Users", "Name_Arab");
            DropColumn("dbo.Users", "Name_English");
            DropColumn("dbo.Users", "Name_French");
            DropColumn("dbo.Individuals", "FirstName_Arab");
            DropColumn("dbo.Individuals", "FirstName_English");
            DropColumn("dbo.Individuals", "FirstName_French");
            DropColumn("dbo.Individuals", "Name_Arab");
            DropColumn("dbo.Individuals", "Name_English");
            DropColumn("dbo.Individuals", "Name_French");
        }
    }
}

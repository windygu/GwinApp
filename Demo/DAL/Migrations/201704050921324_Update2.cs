namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Individuals", "LastName_French", c => c.String());
            AddColumn("dbo.Individuals", "LastName_English", c => c.String());
            AddColumn("dbo.Individuals", "LastName_Arab", c => c.String());
            AddColumn("dbo.Users", "LastName_French", c => c.String());
            AddColumn("dbo.Users", "LastName_English", c => c.String());
            AddColumn("dbo.Users", "LastName_Arab", c => c.String());
            DropColumn("dbo.Individuals", "Name_French");
            DropColumn("dbo.Individuals", "Name_English");
            DropColumn("dbo.Individuals", "Name_Arab");
            DropColumn("dbo.Users", "Name_French");
            DropColumn("dbo.Users", "Name_English");
            DropColumn("dbo.Users", "Name_Arab");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name_Arab", c => c.String());
            AddColumn("dbo.Users", "Name_English", c => c.String());
            AddColumn("dbo.Users", "Name_French", c => c.String());
            AddColumn("dbo.Individuals", "Name_Arab", c => c.String());
            AddColumn("dbo.Individuals", "Name_English", c => c.String());
            AddColumn("dbo.Individuals", "Name_French", c => c.String());
            DropColumn("dbo.Users", "LastName_Arab");
            DropColumn("dbo.Users", "LastName_English");
            DropColumn("dbo.Users", "LastName_French");
            DropColumn("dbo.Individuals", "LastName_Arab");
            DropColumn("dbo.Individuals", "LastName_English");
            DropColumn("dbo.Individuals", "LastName_French");
        }
    }
}

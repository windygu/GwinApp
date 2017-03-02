namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ApplicationNames_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationNames", "Name_French", c => c.String());
            AddColumn("dbo.ApplicationNames", "Name_English", c => c.String());
            AddColumn("dbo.ApplicationNames", "Name_Arab", c => c.String());
            AddColumn("dbo.ApplicationNames", "Description", c => c.String());
            DropColumn("dbo.ApplicationNames", "Names_French");
            DropColumn("dbo.ApplicationNames", "Names_English");
            DropColumn("dbo.ApplicationNames", "Names_Arab");
            DropColumn("dbo.ApplicationNames", "Descriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationNames", "Descriptions", c => c.String());
            AddColumn("dbo.ApplicationNames", "Names_Arab", c => c.String());
            AddColumn("dbo.ApplicationNames", "Names_English", c => c.String());
            AddColumn("dbo.ApplicationNames", "Names_French", c => c.String());
            DropColumn("dbo.ApplicationNames", "Description");
            DropColumn("dbo.ApplicationNames", "Name_Arab");
            DropColumn("dbo.ApplicationNames", "Name_English");
            DropColumn("dbo.ApplicationNames", "Name_French");
        }
    }
}

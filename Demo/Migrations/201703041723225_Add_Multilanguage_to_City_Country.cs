namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Multilanguage_to_City_Country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Name_French", c => c.String());
            AddColumn("dbo.Cities", "Name_English", c => c.String());
            AddColumn("dbo.Cities", "Name_Arab", c => c.String());
            AddColumn("dbo.Cities", "Description_French", c => c.String());
            AddColumn("dbo.Cities", "Description_English", c => c.String());
            AddColumn("dbo.Cities", "Description_Arab", c => c.String());
            AddColumn("dbo.Countries", "Name_French", c => c.String());
            AddColumn("dbo.Countries", "Name_English", c => c.String());
            AddColumn("dbo.Countries", "Name_Arab", c => c.String());
            AddColumn("dbo.Countries", "Description_French", c => c.String());
            AddColumn("dbo.Countries", "Description_English", c => c.String());
            AddColumn("dbo.Countries", "Description_Arab", c => c.String());
            DropColumn("dbo.Cities", "Name");
            DropColumn("dbo.Cities", "Description");
            DropColumn("dbo.Countries", "Name");
            DropColumn("dbo.Countries", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Description", c => c.String());
            AddColumn("dbo.Countries", "Name", c => c.String());
            AddColumn("dbo.Cities", "Description", c => c.String());
            AddColumn("dbo.Cities", "Name", c => c.String());
            DropColumn("dbo.Countries", "Description_Arab");
            DropColumn("dbo.Countries", "Description_English");
            DropColumn("dbo.Countries", "Description_French");
            DropColumn("dbo.Countries", "Name_Arab");
            DropColumn("dbo.Countries", "Name_English");
            DropColumn("dbo.Countries", "Name_French");
            DropColumn("dbo.Cities", "Description_Arab");
            DropColumn("dbo.Cities", "Description_English");
            DropColumn("dbo.Cities", "Description_French");
            DropColumn("dbo.Cities", "Name_Arab");
            DropColumn("dbo.Cities", "Name_English");
            DropColumn("dbo.Cities", "Name_French");
        }
    }
}

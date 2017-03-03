namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Description_Table_ApplicationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationNames", "Description_French", c => c.String());
            AddColumn("dbo.ApplicationNames", "Description_English", c => c.String());
            AddColumn("dbo.ApplicationNames", "Description_Arab", c => c.String());
            DropColumn("dbo.ApplicationNames", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationNames", "Description", c => c.String());
            DropColumn("dbo.ApplicationNames", "Description_Arab");
            DropColumn("dbo.ApplicationNames", "Description_English");
            DropColumn("dbo.ApplicationNames", "Description_French");
        }
    }
}

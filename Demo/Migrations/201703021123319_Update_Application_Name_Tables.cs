namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Application_Name_Tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationNames", "Names_French", c => c.String());
            AddColumn("dbo.ApplicationNames", "Names_English", c => c.String());
            AddColumn("dbo.ApplicationNames", "Names_Arab", c => c.String());
            AddColumn("dbo.ApplicationNames", "Descriptions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationNames", "Descriptions");
            DropColumn("dbo.ApplicationNames", "Names_Arab");
            DropColumn("dbo.ApplicationNames", "Names_English");
            DropColumn("dbo.ApplicationNames", "Names_French");
        }
    }
}

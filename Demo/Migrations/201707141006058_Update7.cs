namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Title_French", c => c.String());
            AddColumn("dbo.Projects", "Title_English", c => c.String());
            AddColumn("dbo.Projects", "Title_Arab", c => c.String());
            DropColumn("dbo.Projects", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Title", c => c.String());
            DropColumn("dbo.Projects", "Title_Arab");
            DropColumn("dbo.Projects", "Title_English");
            DropColumn("dbo.Projects", "Title_French");
        }
    }
}

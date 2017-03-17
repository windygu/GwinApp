namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskProjects", "BusinessEntity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskProjects", "BusinessEntity");
        }
    }
}

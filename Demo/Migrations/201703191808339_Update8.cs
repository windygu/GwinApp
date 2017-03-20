namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationNames", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationNames", "Reference");
        }
    }
}

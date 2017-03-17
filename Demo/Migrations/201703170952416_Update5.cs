namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authorizations", "ActionsNamesAsString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authorizations", "ActionsNamesAsString");
        }
    }
}

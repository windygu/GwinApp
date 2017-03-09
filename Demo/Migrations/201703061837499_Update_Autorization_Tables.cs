namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Autorization_Tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authorizations", "Action_Id", "dbo.UserActions");
            DropIndex("dbo.Authorizations", new[] { "Action_Id" });
            AddColumn("dbo.Authorizations", "EntityName", c => c.String());
            AddColumn("dbo.Authorizations", "Action", c => c.Int(nullable: false));
            DropColumn("dbo.Authorizations", "Name");
            DropColumn("dbo.Authorizations", "Description");
            DropColumn("dbo.Authorizations", "Entity");
            DropColumn("dbo.Authorizations", "Action_Id");
            DropTable("dbo.UserActions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Authorizations", "Action_Id", c => c.Long());
            AddColumn("dbo.Authorizations", "Entity", c => c.String());
            AddColumn("dbo.Authorizations", "Description", c => c.String());
            AddColumn("dbo.Authorizations", "Name", c => c.String());
            DropColumn("dbo.Authorizations", "Action");
            DropColumn("dbo.Authorizations", "EntityName");
            CreateIndex("dbo.Authorizations", "Action_Id");
            AddForeignKey("dbo.Authorizations", "Action_Id", "dbo.UserActions", "Id");
        }
    }
}

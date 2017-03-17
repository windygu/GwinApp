namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleMenuItemApplications", newName: "MenuItemApplicationRoles");
            DropForeignKey("dbo.Authorizations", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Authorizations", new[] { "Role_Id" });
            DropPrimaryKey("dbo.MenuItemApplicationRoles");
            CreateTable(
                "dbo.GwinActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleAuthorizations",
                c => new
                    {
                        Role_Id = c.Long(nullable: false),
                        Authorization_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Authorization_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authorizations", t => t.Authorization_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Authorization_Id);
            
            AddColumn("dbo.Authorizations", "Name", c => c.String());
            AddColumn("dbo.Authorizations", "Description", c => c.String());
            AddColumn("dbo.Authorizations", "BusinessEntity", c => c.String());
            AddPrimaryKey("dbo.MenuItemApplicationRoles", new[] { "MenuItemApplication_Id", "Role_Id" });
            DropColumn("dbo.Authorizations", "EntityName");
            DropColumn("dbo.Authorizations", "Action");
            DropColumn("dbo.Authorizations", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authorizations", "Role_Id", c => c.Long());
            AddColumn("dbo.Authorizations", "Action", c => c.Int(nullable: false));
            AddColumn("dbo.Authorizations", "EntityName", c => c.String());
            DropForeignKey("dbo.RoleAuthorizations", "Authorization_Id", "dbo.Authorizations");
            DropForeignKey("dbo.RoleAuthorizations", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleAuthorizations", new[] { "Authorization_Id" });
            DropIndex("dbo.RoleAuthorizations", new[] { "Role_Id" });
            DropPrimaryKey("dbo.MenuItemApplicationRoles");
            DropColumn("dbo.Authorizations", "BusinessEntity");
            DropColumn("dbo.Authorizations", "Description");
            DropColumn("dbo.Authorizations", "Name");
            DropTable("dbo.RoleAuthorizations");
            DropTable("dbo.GwinActivities");
            AddPrimaryKey("dbo.MenuItemApplicationRoles", new[] { "Role_Id", "MenuItemApplication_Id" });
            CreateIndex("dbo.Authorizations", "Role_Id");
            AddForeignKey("dbo.Authorizations", "Role_Id", "dbo.Roles", "Id");
            RenameTable(name: "dbo.MenuItemApplicationRoles", newName: "RoleMenuItemApplications");
        }
    }
}

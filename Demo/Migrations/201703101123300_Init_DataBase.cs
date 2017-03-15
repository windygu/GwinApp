namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationNames",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name_French = c.String(),
                        Name_English = c.String(),
                        Name_Arab = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EntityName = c.String(),
                        Action = c.Int(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Role_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name_French = c.String(),
                        Name_English = c.String(),
                        Name_Arab = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Country_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name_French = c.String(),
                        Name_English = c.String(),
                        Name_Arab = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Cellphone = c.String(),
                        FaceBook = c.String(),
                        WebSite = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        City_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.TaskProjects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        LocalizedTitle_French = c.String(),
                        LocalizedTitle_English = c.String(),
                        LocalizedTitle_Arab = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DaysNumber = c.Int(nullable: false),
                        EntityToManimulate = c.String(),
                        Categoy = c.Int(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Entity_OneToMany_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Entity_OneToMany_Id)
                .Index(t => t.Entity_OneToMany_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        FirstName = c.String(),
                        CIN = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        ProfilePhoto = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Cellphone = c.String(),
                        FaceBook = c.String(),
                        WebSite = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        City_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.MenuItemApplications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Description_French = c.String(),
                        Description_English = c.String(),
                        Description_Arab = c.String(),
                        Title_French = c.String(),
                        Title_English = c.String(),
                        Title_Arab = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Hidden = c.Boolean(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Language = c.Int(nullable: false),
                        Name = c.String(),
                        FirstName = c.String(),
                        CIN = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        ProfilePhoto = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Cellphone = c.String(),
                        FaceBook = c.String(),
                        WebSite = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        City_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.TaskProjectIndividuals",
                c => new
                    {
                        TaskProject_Id = c.Long(nullable: false),
                        Individual_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskProject_Id, t.Individual_Id })
                .ForeignKey("dbo.TaskProjects", t => t.TaskProject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Individuals", t => t.Individual_Id, cascadeDelete: true)
                .Index(t => t.TaskProject_Id)
                .Index(t => t.Individual_Id);
            
            CreateTable(
                "dbo.TaskProjectIndividual1",
                c => new
                    {
                        TaskProject_Id = c.Long(nullable: false),
                        Individual_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskProject_Id, t.Individual_Id })
                .ForeignKey("dbo.TaskProjects", t => t.TaskProject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Individuals", t => t.Individual_Id, cascadeDelete: true)
                .Index(t => t.TaskProject_Id)
                .Index(t => t.Individual_Id);
            
            CreateTable(
                "dbo.RoleMenuItemApplications",
                c => new
                    {
                        Role_Id = c.Long(nullable: false),
                        MenuItemApplication_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.MenuItemApplication_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.MenuItemApplications", t => t.MenuItemApplication_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.MenuItemApplication_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.RoleMenuItemApplications", "MenuItemApplication_Id", "dbo.MenuItemApplications");
            DropForeignKey("dbo.RoleMenuItemApplications", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Authorizations", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.TaskProjectIndividual1", "Individual_Id", "dbo.Individuals");
            DropForeignKey("dbo.TaskProjectIndividual1", "TaskProject_Id", "dbo.TaskProjects");
            DropForeignKey("dbo.TaskProjectIndividuals", "Individual_Id", "dbo.Individuals");
            DropForeignKey("dbo.TaskProjectIndividuals", "TaskProject_Id", "dbo.TaskProjects");
            DropForeignKey("dbo.Individuals", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.TaskProjects", "Entity_OneToMany_Id", "dbo.Projects");
            DropForeignKey("dbo.ContactInformations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.RoleMenuItemApplications", new[] { "MenuItemApplication_Id" });
            DropIndex("dbo.RoleMenuItemApplications", new[] { "Role_Id" });
            DropIndex("dbo.TaskProjectIndividual1", new[] { "Individual_Id" });
            DropIndex("dbo.TaskProjectIndividual1", new[] { "TaskProject_Id" });
            DropIndex("dbo.TaskProjectIndividuals", new[] { "Individual_Id" });
            DropIndex("dbo.TaskProjectIndividuals", new[] { "TaskProject_Id" });
            DropIndex("dbo.Users", new[] { "City_Id" });
            DropIndex("dbo.Roles", new[] { "User_Id" });
            DropIndex("dbo.Individuals", new[] { "City_Id" });
            DropIndex("dbo.TaskProjects", new[] { "Entity_OneToMany_Id" });
            DropIndex("dbo.ContactInformations", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Authorizations", new[] { "Role_Id" });
            DropTable("dbo.RoleMenuItemApplications");
            DropTable("dbo.TaskProjectIndividual1");
            DropTable("dbo.TaskProjectIndividuals");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.MenuItemApplications");
            DropTable("dbo.Individuals");
            DropTable("dbo.Projects");
            DropTable("dbo.TaskProjects");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Authorizations");
            DropTable("dbo.ApplicationNames");
        }
    }
}

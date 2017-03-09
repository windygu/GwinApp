namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntityMinConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityMiniConfigs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StringField = c.String(),
                        MultiLine_StingField = c.String(),
                        LocalizedString_French = c.String(),
                        LocalizedString_English = c.String(),
                        LocalizedString_Arab = c.String(),
                        DateTimeField = c.DateTime(nullable: false),
                        IntField = c.Int(nullable: false),
                        StringWithDataSource = c.String(),
                        Enumeration = c.Int(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Entity_OneToMany_Id = c.Long(),
                        ManyToMany_Creation_Id = c.Long(),
                        ManyToMany_Selection_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity_OneToMany", t => t.Entity_OneToMany_Id)
                .ForeignKey("dbo.Entity_ManyToMany", t => t.ManyToMany_Creation_Id)
                .ForeignKey("dbo.Entity_ManyToMany", t => t.ManyToMany_Selection_Id)
                .Index(t => t.Entity_OneToMany_Id)
                .Index(t => t.ManyToMany_Creation_Id)
                .Index(t => t.ManyToMany_Selection_Id);
            
            CreateTable(
                "dbo.Entity_OneToMany",
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
                "dbo.Entity_ManyToMany",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.MinimumConfiguration_Loalizable_Entity");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MinimumConfiguration_Loalizable_Entity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StingField = c.String(),
                        MultiLine_StingField = c.String(),
                        IntField = c.Int(nullable: false),
                        DateTimeField = c.DateTime(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id", "dbo.Entity_ManyToMany");
            DropForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id", "dbo.Entity_ManyToMany");
            DropForeignKey("dbo.EntityMiniConfigs", "Entity_OneToMany_Id", "dbo.Entity_OneToMany");
            DropIndex("dbo.EntityMiniConfigs", new[] { "ManyToMany_Selection_Id" });
            DropIndex("dbo.EntityMiniConfigs", new[] { "ManyToMany_Creation_Id" });
            DropIndex("dbo.EntityMiniConfigs", new[] { "Entity_OneToMany_Id" });
            DropTable("dbo.Entity_ManyToMany");
            DropTable("dbo.Entity_OneToMany");
            DropTable("dbo.EntityMiniConfigs");
        }
    }
}

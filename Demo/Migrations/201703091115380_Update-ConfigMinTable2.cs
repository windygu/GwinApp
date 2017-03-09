namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConfigMinTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id", "dbo.Entity_ManyToMany");
            DropForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id", "dbo.Entity_ManyToMany");
            DropIndex("dbo.EntityMiniConfigs", new[] { "ManyToMany_Creation_Id" });
            DropIndex("dbo.EntityMiniConfigs", new[] { "ManyToMany_Selection_Id" });
            CreateTable(
                "dbo.EntityMiniConfigEntity_ManyToMany",
                c => new
                    {
                        EntityMiniConfig_Id = c.Long(nullable: false),
                        Entity_ManyToMany_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EntityMiniConfig_Id, t.Entity_ManyToMany_Id })
                .ForeignKey("dbo.EntityMiniConfigs", t => t.EntityMiniConfig_Id, cascadeDelete: true)
                .ForeignKey("dbo.Entity_ManyToMany", t => t.Entity_ManyToMany_Id, cascadeDelete: true)
                .Index(t => t.EntityMiniConfig_Id)
                .Index(t => t.Entity_ManyToMany_Id);
            
            CreateTable(
                "dbo.EntityMiniConfigEntity_ManyToMany1",
                c => new
                    {
                        EntityMiniConfig_Id = c.Long(nullable: false),
                        Entity_ManyToMany_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EntityMiniConfig_Id, t.Entity_ManyToMany_Id })
                .ForeignKey("dbo.EntityMiniConfigs", t => t.EntityMiniConfig_Id, cascadeDelete: true)
                .ForeignKey("dbo.Entity_ManyToMany", t => t.Entity_ManyToMany_Id, cascadeDelete: true)
                .Index(t => t.EntityMiniConfig_Id)
                .Index(t => t.Entity_ManyToMany_Id);
            
            DropColumn("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id");
            DropColumn("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id", c => c.Long());
            AddColumn("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id", c => c.Long());
            DropForeignKey("dbo.EntityMiniConfigEntity_ManyToMany1", "Entity_ManyToMany_Id", "dbo.Entity_ManyToMany");
            DropForeignKey("dbo.EntityMiniConfigEntity_ManyToMany1", "EntityMiniConfig_Id", "dbo.EntityMiniConfigs");
            DropForeignKey("dbo.EntityMiniConfigEntity_ManyToMany", "Entity_ManyToMany_Id", "dbo.Entity_ManyToMany");
            DropForeignKey("dbo.EntityMiniConfigEntity_ManyToMany", "EntityMiniConfig_Id", "dbo.EntityMiniConfigs");
            DropIndex("dbo.EntityMiniConfigEntity_ManyToMany1", new[] { "Entity_ManyToMany_Id" });
            DropIndex("dbo.EntityMiniConfigEntity_ManyToMany1", new[] { "EntityMiniConfig_Id" });
            DropIndex("dbo.EntityMiniConfigEntity_ManyToMany", new[] { "Entity_ManyToMany_Id" });
            DropIndex("dbo.EntityMiniConfigEntity_ManyToMany", new[] { "EntityMiniConfig_Id" });
            DropTable("dbo.EntityMiniConfigEntity_ManyToMany1");
            DropTable("dbo.EntityMiniConfigEntity_ManyToMany");
            CreateIndex("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id");
            CreateIndex("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id");
            AddForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Selection_Id", "dbo.Entity_ManyToMany", "Id");
            AddForeignKey("dbo.EntityMiniConfigs", "ManyToMany_Creation_Id", "dbo.Entity_ManyToMany", "Id");
        }
    }
}

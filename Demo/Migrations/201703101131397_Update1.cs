namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TaskProjects", name: "Entity_OneToMany_Id", newName: "Project_Id");
            RenameIndex(table: "dbo.TaskProjects", name: "IX_Entity_OneToMany_Id", newName: "IX_Project_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TaskProjects", name: "IX_Project_Id", newName: "IX_Entity_OneToMany_Id");
            RenameColumn(table: "dbo.TaskProjects", name: "Project_Id", newName: "Entity_OneToMany_Id");
        }
    }
}

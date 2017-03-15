namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskProjects", "Valide", c => c.Boolean(nullable: false));
            AddColumn("dbo.TaskProjects", "var_Int16", c => c.Short(nullable: false));
            AddColumn("dbo.TaskProjects", "var_Int64", c => c.Long(nullable: false));
            AddColumn("dbo.TaskProjects", "var_float", c => c.Single(nullable: false));
            AddColumn("dbo.TaskProjects", "var_double", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskProjects", "var_double");
            DropColumn("dbo.TaskProjects", "var_float");
            DropColumn("dbo.TaskProjects", "var_Int64");
            DropColumn("dbo.TaskProjects", "var_Int16");
            DropColumn("dbo.TaskProjects", "Valide");
        }
    }
}

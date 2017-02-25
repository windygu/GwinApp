namespace App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WinForm.Application.BAL;
    using WinForm.Entities.Authentication;
    using WinForm.Entities.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GeneticWinFormApp";
        }

        protected override void Seed(App.ModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Projets.AddOrUpdate(
            //  p => p.Id
            //  ,
            //  new Project { Id = 1, Title = "Projet 1" },
            //  new Project { Id = 1, Title = "Projet 2" },
            //   new Project { Id = 1, Title = "Projet 3" }
            //);

            context.Roles.AddOrUpdate(
                 r => r.Id
              ,
              new Role { Id = 1, Name = "Root",Hidden= true },
              new Role { Id = 2, Name = "Admin" },
              new Role { Id = 3, Name = "User" },
              new Role { Id = 4, Name = "Project Management system" }
            );

            InstallApplicationGwinBLO InstallApplication = new InstallApplicationGwinBLO(typeof(ModelContext));
            InstallApplication.Update();

        }
    }
}

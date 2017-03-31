namespace App.Migrations
{
    using GenericWinForm.Demo.DAL;
    using GenericWinForm.Demo.Entities;
    using Gwin;
    using Gwin.Application.BAL;
    using Gwin.Entities.Application;
    using Gwin.Entities.Secrurity.Autorizations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GwinApp";
        }

        protected override void Seed(ModelContext context)
        {
            //Gin Application Name
            context.ApplicationNames.AddOrUpdate(
                           r => r.Reference
                        ,
                        new App.Gwin.Entities.Application.ApplicationName
                        {
                            Reference = "Demo",
                            Name = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تجريب برنامج الكوين", English = "Gwin Application Demo", French = "Démonstration de l'application Gwin" }
                        }

                      );

            // Gwin Default Rols
            context.Roles.AddOrUpdate(
                 r => r.Reference
                        ,
              new Role { Id = 1, Reference = "Root", Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = "Root" }, Hidden = true },
              new Role { Id = 2, Reference = "Admin", Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = "Admin" } },
              new Role { Id = 3, Reference = "User", Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = "User" } }
            );

            // Gwin Default Menu
            context.MenuItemApplications.AddOrUpdate(
                            r => r.Code
                         ,
                         new MenuItemApplication { Id = 1, Code = "Configuration", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "إعدادات", English = "Configuration", French = "Configuration" } },
                         new MenuItemApplication { Id = 2, Code = "Admin", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير البرنامج", English = "Admin", French = "Administration" } },
                         new MenuItemApplication { Id = 3, Code = "Root", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "مصمم اليرنامج", English = "Application Constructor", French = "Rélisateur de l'application" } }
                       );

            // Gwin Test Default Values
            context.EntityMiniConfigs.AddOrUpdate(
                 o => o.Id
              ,
              new TaskProject
              {
                  Id = 1,
                  StartDate = DateTime.Now,
                  Project = new Project() { Id = 1, Title = "Entity_OneToMany" },
                  Categoy = TaskCategory.Analysis,
                  DaysNumber = 3,
                  Title = "Create Uses Cases Diagrame",
                  Description = "Create UML Uses Cases Diagrams for Club Management system",
                  LocalizedTitle = new Gwin.Entities.MultiLanguage.LocalizedString() { Arab = "تحليل وظيفي", French = "Analyse fonctionnelle" },
                  Peoples = new List<Individual>() {
                      new Individual() { Name = "Mouad",FirstName = "Madani"},
                      new Individual() { Name = "Mouad",FirstName = "Kamal"}
                  },
                  Responsibles = new List<Individual>() {
                      new Individual() { Name = "Mouana", FirstName = "Chami" },
                      new Individual() { Name = "Kamal", FirstName = "Chami" }
                  },
              }

            );
        }
    }
}

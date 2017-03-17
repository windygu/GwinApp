namespace App.Migrations
{
    using GenericWinForm.Demo.Entities;
    using Gwin;
    using Gwin.Application.BAL;
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

        protected override void Seed(App.ModelContext context)
        {
     
            context.Roles.AddOrUpdate(
                 r => r.Id
              ,
              new Role { Id = 1, Name = "Root",Hidden= true },
              new Role { Id = 2, Name = "Admin" },
              new Role { Id = 3, Name = "User" },
              new Role { Id = 4, Name = "Project Management system" }
            );

            context.EntityMiniConfigs.AddOrUpdate(
                 o => o.Id
              ,
              new TaskProject {
                  Id = 1,
                  StartDate = DateTime.Now,
                  Project = new Project() { Id = 1,Title = "Entity_OneToMany"},
                  Categoy = TaskCategory.Analysis,
                  DaysNumber = 3,
                  Title = "Create Uses Cases Diagrame",
                  Description = "Create UML Uses Cases Diagrams for Club Management system",
                  LocalizedTitle = new Gwin.Entities.MultiLanguage.LocalizedString() { Arab = "تحليل وظيفي" ,French = "Analyse fonctionnelle"},
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

namespace App.Migrations
{
    using App.Gwin.Entities.Secrurity.Authentication;
    using GenericWinForm.Demo.DAL;
    using GenericWinForm.Demo.Entities;
    using Gwin;
    using Gwin.Application.BAL;
    using Gwin.Entities.Application;
    using Gwin.Entities.MultiLanguage;
    using Gwin.Entities.Secrurity.Autorizations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            // Gwin  Roles
            Role RoleGuest = null;
            Role RoleRoot = null;
            context.Roles.AddOrUpdate(
                 r => r.Reference
                        ,
              RoleGuest = new Role { Reference = nameof(Role.Roles.Guest), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Guest) } },
              new Role { Reference = nameof(Role.Roles.User), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.User) } },
              new Role { Reference = nameof(Role.Roles.Admin), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Admin) } },
              new Role { Reference = nameof(Role.Roles.Root), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Root) }, Hidden = true }
            );


            RoleRoot = context.Set<Role>().Where(r => r.Reference == nameof(Role.Roles.Root)).SingleOrDefault();
            RoleGuest = context.Set<Role>().Where(r => r.Reference == nameof(Role.Roles.Guest)).SingleOrDefault();
            // Giwn Users
            context.Users.AddOrUpdate(
                u => u.Reference,
                new User() { Reference =  nameof(User.Users.Root), Login = "root", Password = "root", LastName = new LocalizedString() { Current = nameof(User.Users.Root) } ,Roles = new List<Role>() { RoleRoot } },
                  new User() { Reference = nameof(User.Users.Guest), Login = nameof(User.Users.Guest), Password = nameof(User.Users.Guest), LastName = new LocalizedString() { Current = nameof(User.Users.Guest) } , Roles = new List<Role>() { RoleGuest } }
                );

            

            // Gwin  Menu
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
                      new Individual() { LastName = new LocalizedString() {Current = "Mouad" },FirstName = new LocalizedString() {Current = "Madani"} }, 
                      new Individual() { LastName = new LocalizedString() {Current = "Mouad" }  ,FirstName = new LocalizedString() {Current = "Kamal" } }
                  },
                  Responsibles = new List<Individual>() {
                      new Individual() { LastName = new LocalizedString() {Current = "Mouana"} , FirstName =new LocalizedString() {Current = "Chami"}  },
                      new Individual() { LastName = new LocalizedString() {Current = "Kamal"}, FirstName =new LocalizedString() {Current = "Chami"}  }
                  },
              }

            );
        }
    }
}

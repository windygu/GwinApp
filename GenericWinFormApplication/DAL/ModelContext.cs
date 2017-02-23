namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using WinForm.Entities.Application;
    using WinForm.Entities.Authentication;
    using WinForm.Entities.ContactInformations;
    using WinForm.Entities.Security;

    public class ModelContext : DbContext
    {

        public ModelContext() : base(@"data source =.\SQLEXPRESS; initial catalog = generic-winapp-demo; user = sa; password = admintp4; MultipleActiveResultSets = True; App = EntityFramework")
        {
          
        }

        public ModelContext(string connectionString):base(connectionString)
        {

        }

        //
        // WinForm : Authentication
        //
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //
        // WinFrom : Application
        //
        public virtual DbSet<MenuItemApplication> MenuItemApplications { get; set; }

        //
        // WinForm : ContactInformationss
        // 
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }


        ////
        //// Project management system
        ////
        //public virtual DbSet<Project> Projets { get; set; }
        //public virtual DbSet<ProjectTask> Taches { get; set; }
        //public virtual DbSet<ProjectCategory> ProjectCategorys { get; set; }
        //public virtual DbSet<RessouceProject> RessouceProjects { get; set; }

 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }


        /// <summary>
        /// trouver la liste des type des objets dans le context
        /// </summary>
        /// <returns></returns>
        public List<Type> GetTypesSets()
        {
           
            var sets = from p in typeof(ModelContext).GetProperties() where p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) let entityType = p.PropertyType.GetGenericArguments().First() select p.PropertyType.GetGenericArguments()[0];
            return sets.ToList<Type>();
        }

    }

    


}
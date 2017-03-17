namespace App
{
    using GenericWinForm.Demo.Entities;
    using Gwin.Entities.Application;
    using Gwin.Entities.ContactInformations;
    using Gwin.Entities.Logging;
    using Gwin.Entities.Secrurity.Authentication;
    using Gwin.Entities.Secrurity.Autorizations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {

        public ModelContext() : base(@"data source =.\SQLEXPRESS; initial catalog = gwin-demo2; user = sa; password = admintp4; MultipleActiveResultSets = True; App = EntityFramework")
        {
          
        }

        public ModelContext(string connectionString):base(connectionString)
        {

        }

        //
        // Gwin : Entites
        //
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<GwinActivity> GwinActivities { get; set; }
        public virtual DbSet<MenuItemApplication> MenuItemApplications { get; set; }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }
        public virtual DbSet<ApplicationName> ApplicationNames { get; set; }


        // Demo
        public virtual DbSet<TaskProject> EntityMiniConfigs { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskProject>()
                .HasMany<Individual>(s => s.Peoples)
                .WithMany(c => c.Histasks);

            modelBuilder.Entity<TaskProject>()
                .HasMany<Individual>(s => s.Responsibles)
                .WithMany(c => c.ResponsibilityFortasks);

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
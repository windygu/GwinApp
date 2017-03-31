using App.Gwin.Entities.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.GwinApplication.BLL.Configuration
{
    /// <summary>
    /// ConfigDb Business Logique
    /// </summary>
    public class ConfigDbBLO
    {
        /// <summary>
        /// Create Default DataBase configuration
        /// MSLocalDB
        /// </summary>
        /// <returns></returns>
        private ConfigDb CreateDefaultConfiguration()
        {
            ConfigDb configDb = new ConfigDb();
            configDb.SupportedDataBaseCategories = Enumerations.Configuration.SupportedDataBaseCategories.LocalDataBase;
            configDb.SupportedLocalDataBases = Enumerations.Configuration.SupportedLocalDataBases.Microsoft_LocalDB;
            return configDb;
        }

        /// <summary>
        /// Read ConfigDb object from XML 
        /// </summary>
        public ConfigDb ReadConfigDb()
        {
            // Read XML Cofig File if Exist

            // Create Default Configuration if ConfigFile not exist
            return this.CreateDefaultConfiguration();
        }

        public string getConnectionString()
        {
            // SQL Server ConnectionString
            //SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            //sqlBuilder.DataSource = "XXX";
            //sqlBuilder.InitialCatalog = "YYY";
            //sqlBuilder.PersistSecurityInfo = true;
            //sqlBuilder.IntegratedSecurity = true;
            //sqlBuilder.MultipleActiveResultSets = true;

            //EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            //entityBuilder.Metadata = "res://*/";
            //entityBuilder.Provider = "System.Data.SqlClient";

            // LocalDb Connecion String
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = @"(LocalDb)\MSSQLLocalDB";
            sqlBuilder.InitialCatalog = "Gwin.Demo";
           // sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.MultipleActiveResultSets = true;
        
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Provider = "System.Data.SqlClient";

            //string connectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Gwin.Demo;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string connectionString = sqlBuilder.ToString();
            return connectionString;
        }
    }
}

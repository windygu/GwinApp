using GApp.GwinApp.Enumerations.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Entities.Configuration
{
    /// <summary>
    /// DataBase connexion configuration
    /// </summary>
    public class ConfigDb
    {
        public SupportedDataBaseCategories SupportedDataBaseCategories { set; get; }
        public SupportedServerDataBases SupportedServerDataBases { set; get; }
        public SupportedLocalDataBases SupportedLocalDataBases { set; get; }
        public string ServerName { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string DataBaseName { set; get; }
    }
}

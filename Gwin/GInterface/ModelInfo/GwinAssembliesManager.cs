using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.DataModel.ModelInfo
{
    /// <summary>
    /// Gwin Assemnply Manager
    /// </summary>
    public class GwinAssembliesManager
    {
        /// <summary>
        /// Get All Assebply that containes Entities
        /// </summary>
        /// <returns>List of Assembly</returns>
        public List<Assembly> GetAll_Assembly_Contains_Entities()
        {
            //[Bug] it not load All Entities en Project
            return AppDomain.CurrentDomain.GetAssemblies()
                     .Where(a => (!a.FullName.Contains("DynamicProxies")
                     && (a.FullName.Contains("Entities")                                      // Entities Assemply
                     || a.FullName.Contains(GwinApp.Instance.GetType().Assembly.FullName)        // Gwin Assemply
                     || a.FullName.Contains(GwinApp.Instance.TypeDBContext.Assembly.FullName)    // DAL Assemply
                     ))
                     ).Cast<Assembly>().ToList<Assembly>();
        }

        /// <summary>
        /// Get All Assebply that containes BusinessEntities
        /// </summary>
        /// <returns>List of Assembly</returns>
        public List<Assembly> GetAll_Assembly_Contains_BusinessEntities()
        {
            //[Bug] it not load All Entities en Project
            return AppDomain.CurrentDomain.GetAssemblies()
                     .Where(a => (!a.FullName.Contains("DynamicProxies")
                     && (a.FullName.Contains("BLO")                                      //Business Entities Assemply
                     || a.FullName.Contains(GwinApp.Instance.GetType().Assembly.FullName)        // Gwin Assemply
                     || a.FullName.Contains(GwinApp.Instance.TypeDBContext.Assembly.FullName)    // DAL Assemply
                     ))
                     ).Cast<Assembly>().ToList<Assembly>();
        }

    }
}

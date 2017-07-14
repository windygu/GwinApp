using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.DataModel.Helpers
{
    public class GwinIdentifierManager
    {

        /// <summary>
        /// Returns the plural form of the specified name
        /// </summary>
        /// <param name="SingulareName">Singlural name</param>
        /// <returns></returns>
        public static string Pluralize(String SingulareName)
        {
            PluralizationService pluralizationService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
            return pluralizationService.Pluralize(SingulareName);

        }
    }
}

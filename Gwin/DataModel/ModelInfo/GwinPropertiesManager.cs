using GApp.GwinApp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.DataModel.ModelInfo
{
    public class GwinPropertiesManager
    {
        public List<PropertyInfo> GetPropertiesShowenInEntryForm(Type TypeEntity)
        {
            // Get Properties to show in Entry Form
            var listeProprite = from i in TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(EntryFormAttribute)) != null
                                orderby ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).Ordre
                                select i;

            return listeProprite.ToList<PropertyInfo>();
        }
    }
}

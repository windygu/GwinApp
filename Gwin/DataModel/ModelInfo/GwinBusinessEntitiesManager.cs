using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.DataModel.ModelInfo
{
    public class GwinBusinessEntitiesManager
    {
 
        /// <summary>
        /// Get All Entities in Project 
        /// </summary>
        /// <returns>List of BLO Types</returns>
        public  object GetAll(Type typeAttribute)
        {

            List<Type> Liste_All_BLO_types = (from assembly in new GwinAssembliesManager().GetAll_Assembly_Contains_BusinessEntities()
                                                   from type in assembly.GetTypes()
                                                   let attributes = type.GetCustomAttributes(typeAttribute, false)
                                                   where attributes != null && attributes.Length > 0
                                                   select type
           ).ToList();


            return Liste_All_BLO_types;
        }
    }
}

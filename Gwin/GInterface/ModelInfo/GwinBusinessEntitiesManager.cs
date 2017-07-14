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
        /// Get All BLO in Project 
        /// </summary>
        /// <param name="typeAttribute">Attribute used to Selected BLO Entity</param>
        /// <param name="IncludeGeneticType">Select Genetic BLO from Entities Type</param>
        /// <returns>List of BLO Types</returns>
        public object GetAll(Type typeAttribute, bool IncludeGeneticType)
        {

            List<Type> Liste_All_BLO_types = (from assembly in new GwinAssembliesManager().GetAll_Assembly_Contains_BusinessEntities()
                                              from type in assembly.GetTypes()
                                              let attributes = type.GetCustomAttributes(typeAttribute, false)
                                              where attributes != null && attributes.Length > 0
                                              select type
           ).ToList();

            if (IncludeGeneticType)
            {
                List<Type> ListeEntitiesTypes = new GwinEntitiesManager().GetAll_Entities_Type();

                //Delete Existance Type in ListeEntitiesTypes that his BLO indluded  in  Liste_All_BLO_types
                for (int i = 0; i < ListeEntitiesTypes.Count; i++)
                {
                    Type element = Liste_All_BLO_types.Where(t => t.BaseType.GenericTypeArguments.Contains(ListeEntitiesTypes[i])).SingleOrDefault();
                    if (element != null)
                    {
                        ListeEntitiesTypes.Remove(ListeEntitiesTypes[i]);
                        i--;
                    }
                }
              

                foreach (var item in ListeEntitiesTypes)
                {

                    Type TypeBLO = GwinApp.Instance.TypeBaseBLO.MakeGenericType(item);
                    Liste_All_BLO_types.Add(TypeBLO);
                }
            }


            return Liste_All_BLO_types;
        }

        
    }
}

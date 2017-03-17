﻿using App.Gwin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.DataModel.ModelInfo
{
    public class GwinEntitiesManager
    {
        /// <summary>
        /// Get All Entities in Project 
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAll_Entities_Type()
        {

            List<Type> Liste_All_Entities_types = (from assembly in new GwinAssembliesManager().GetAll_Assembly_Contains_Entities()
                                                   from type in assembly.GetTypes()
                                                   let attributes = type.GetCustomAttributes(typeof(GwinEntityAttribute), false)
                                                   where attributes != null && attributes.Length > 0
                                                   select type
           ).ToList();


            return Liste_All_Entities_types;
        }


        /// <summary>
        /// Get All Entity Type in Project
        /// </summary>
        /// <returns> Dictionary : Type, MenuAttributes </returns>
        public Dictionary<Type, MenuAttribute> Get_All_Type_And_MenuAttributes()
        {
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = new Dictionary<Type, MenuAttribute>();
            var ls_Type_MenyAttribute = (from assembly in new GwinAssembliesManager().GetAll_Assembly_Contains_Entities()
                                         from type in assembly.GetTypes()
                                         let attributes = type.GetCustomAttributes(typeof(MenuAttribute), true)
                                         where attributes != null && attributes.Length > 0
                                         select new { Type = type, ApplicationMenu = attributes.Cast<MenuAttribute>().First() }
           ).ToList();

            foreach (var item in ls_Type_MenyAttribute)
            {
                Dictionary_Type_MenyAttribute.Add(item.Type, item.ApplicationMenu);
            }
            return Dictionary_Type_MenyAttribute;
        }
    }
}

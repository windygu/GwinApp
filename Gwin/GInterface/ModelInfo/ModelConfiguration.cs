﻿
using App.Gwin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.ModelData
{
    /// <summary>
    /// Model Configuration from Entities attributes
    /// </summary>
    public class ModelConfiguration
    {
        /// <summary>
        /// Data Categories returns in ModelConfiguration
        /// </summary>
        public enum DataCategories
        {
            Entities,
            Assemblies,
        }

        /// <summary>
        /// Get All Assebply that containes Entities
        /// </summary>
        /// <returns>List of Assembly</returns>
        [Obsolete]
        public List<Assembly> GetAll_Assembly_Contains_Entities()
        {
          //[Bug] it not load All Entities en Project
          return   AppDomain.CurrentDomain.GetAssemblies()
                   .Where(a => (!a.FullName.Contains("DynamicProxies")
                   && (a.FullName.Contains("Entities")                                      // Entities Assemply
                   || a.FullName.Contains(GwinApp.Instance.GetType().Assembly.FullName)        // Gwin Assemply
                   || a.FullName.Contains(GwinApp.Instance.TypeDBContext.Assembly.FullName)    // DAL Assemply
                   ))
                   ).Cast<Assembly>().ToList<Assembly>();
        }

        /// <summary>
        /// Get All Entities in Project 
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public List<Type> GetAll_Entities_Type()
        {

            List<Type> Liste_All_Entities_types = (from assembly in this.GetAll_Assembly_Contains_Entities()
                                         from type in assembly.GetTypes()
                                         let attributes = type.GetCustomAttributes(typeof(GwinEntityAttribute), false)
                                         where attributes != null && attributes.Length > 0
                                         select  type
           ).ToList();

            
            return Liste_All_Entities_types;
        }

        /// <summary>
        /// Get All Entity Type in Project with MenuAttribute
        /// And All Form With MenuAttribute
        /// </summary>
        /// <returns> Dictionary : Type, MenuAttributes </returns>
        [Obsolete]
        public Dictionary<Type, MenuAttribute> Get_All_Type_And_MenuAttributes()
        {
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = new Dictionary<Type, MenuAttribute>();
            var ls_Type_MenyAttribute = (from assembly in this.GetAll_Assembly_Contains_Entities()
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


        /// <summary>
        /// Get All Entities in Project 
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAll_EntitiesBLO(Type TypeAttribute)
        {

            List<Type> Liste_All_Entities_types = (from assembly in this.GetAll_Assembly_Contains_Entities()
                                                   from type in assembly.GetTypes()
                                                   let attributes = type.GetCustomAttributes(TypeAttribute, false)
                                                   where attributes != null && attributes.Length > 0
                                                   select type
           ).ToList();


            return Liste_All_Entities_types;
        }


    }
}

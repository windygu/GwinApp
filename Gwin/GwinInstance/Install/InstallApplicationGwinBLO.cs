using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
using App.Gwin.ModelData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Application.BAL
{
    /// <summary>
    /// Configuration After Update or first installation
    /// </summary>
    public class InstallApplicationGwinBLO
    {
        /// <summary>
        /// ModelContext type,
        /// it used to create EF DBContext instance
        /// </summary>
        private Type TypeModelContext { get;  set; }

        public InstallApplicationGwinBLO(Type type_model_context)
        {
            this.TypeModelContext = type_model_context;
           

        }

        /// <summary>
        /// Must be executed befor the first use of the application
        /// </summary>
        public void Install()
        {

        }
        /// <summary>
        /// Must be executed after DataBase the modification 
        /// of the application
        /// - It Add Items into TabnleMenu
        /// </summary>
        public void Update()
        {
            //
            // Update Table Menu form Entities
            //

            // Create MenuItemApplicationBLO Instance
            var ModelContext = Activator.CreateInstance(TypeModelContext);
            IGwinBaseBLO menuItemApplicationBLO = new GwinBaseBLO<MenuItemApplication>((DbContext)ModelContext);

            DbSet<MenuItemApplication> MenuItemApplicationSet =(DbSet < MenuItemApplication >) this.TypeModelContext.GetProperty("MenuItemApplications").GetValue(ModelContext);

            ModelConfiguration entitiesModel = new ModelConfiguration();

            // Add MeniItemMenu for each Entities that has Menu configuration
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = entitiesModel.Get_All_Type_And_MenuAttributes();
            foreach (var item in Dictionary_Type_MenyAttribute.Values)
            {
             if (item.Group == null) continue;
                if (menuItemApplicationBLO.Recherche(new Dictionary<string, object> { { nameof(MenuItemApplication.Code), item.Group } }).Count == 0)
                    menuItemApplicationBLO.Save(new MenuItemApplication { Code = item.Group,Title = new Entities.MultiLanguage.LocalizedString(),Description = new Entities.MultiLanguage.LocalizedString() });
            }


        }
    }
}

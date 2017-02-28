using App.WinForm.Attributes;
using App.WinForm.Entities.Application;
using App.WinForm.ModelData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Application.BAL
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
            //Update Table Menu form Entities
            var ModelContext = Activator.CreateInstance(TypeModelContext);
            IBaseBLO service = new BaseEntityBLO<MenuItemApplication>((DbContext)ModelContext);

            DbSet<MenuItemApplication> MenuItemApplicationSet =(DbSet < MenuItemApplication >) this.TypeModelContext.GetProperty("MenuItemApplications").GetValue(ModelContext);
            ModelConfiguration entitiesModel = new ModelConfiguration();
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = entitiesModel.Get_All_Type_And_MenuAttributes();
            foreach (var item in Dictionary_Type_MenyAttribute.Values)
            {
             if (item.Group == null) continue;
                if (service.Recherche(new Dictionary<string, object> { { "Name", item.Group } }).Count == 0)
                    service.Save(new MenuItemApplication { Name = item.Group });
            }


        }
    }
}

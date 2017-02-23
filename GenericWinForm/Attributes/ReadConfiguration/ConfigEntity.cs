using App.WinForm.Security;
using App.WinForm.Entities;
using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Design.PluralizationServices;
using System.Threading;
using System.Collections.Generic;
using App.WinForm.Shared.Resources;
using App.WinForm.Application.Presentation.Messages;

namespace App.WinForm.Attributes
{
    /// <summary>
    /// Read Entity configuration
    /// </summary>
    public class ConfigEntity
    {
        #region Public Properties
        public DisplayEntityAttribute DisplayEntity { set; get; }
        public ManagementFormAttribute ManagementForm { set; get; }
        public AddButtonAttribute AddButton { set; get; }
        public MenuAttribute Menu { set; get; }
        #endregion

        #region Private Properties
        private Type TypeOfEntity { set; get; }
        private bool Localizable { get; set; }
        /// <summary>
        /// Culture Info
        /// </summary>
        private CultureInfo CultureInfo { get;  set; }
        /// <summary>
        /// Entity Ressource manager
        /// </summary>
        public Dictionary<string, ResourceManager> RessourcesManagers { get; private set; }

        ResourceManager baseEntityResourceManager = null;

        private static Dictionary<Type,ConfigEntity> SingletonPerTypeValues { get; set; }
        #endregion


        public ConfigEntity(Type type_of_entity)
        {
            this.TypeOfEntity = type_of_entity;
            this.CultureInfo = Thread.CurrentThread.CurrentCulture;
            this.ReadConfiguration();
        }

        /// <summary>
        /// Create Singeloton ConfigEntity per TypeOfEntity
        /// </summary>
        /// <param name="type_of_entity"></param>
        /// <returns></returns>
        public static ConfigEntity CreateConfigEntity(Type type_of_entity)
        {
            if (SingletonPerTypeValues == null)
                SingletonPerTypeValues = new Dictionary<Type, ConfigEntity>();

            if (!SingletonPerTypeValues.Keys.Contains(type_of_entity))
                SingletonPerTypeValues[type_of_entity] = new ConfigEntity(type_of_entity);
         
            return SingletonPerTypeValues[type_of_entity];
        }


      

        /// <summary>
        /// Read configuration of entity
        /// </summary>
        private void ReadConfiguration()
        {
            #region Load RessouceManager  
            //Fill RessouceManager
            this.RessourcesManagers = new Dictionary<string, ResourceManager>();
            RessoucesManagerHelper.FillResourcesManager(this.TypeOfEntity, this.RessourcesManagers);
  
            // BaseEntity RessouceManager
            string BaseEntityRessouceFullName = typeof(BaseEntity).Namespace + ".Resources." + typeof(BaseEntity).Name + "." + typeof(BaseEntity).Name;
            baseEntityResourceManager = new ResourceManager(BaseEntityRessouceFullName, typeof(BaseEntity).Assembly);

            #endregion

            #region Read DisplayEntityAttribute
            Object[] ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(DisplayEntityAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0)
                throw new AnnotationNotExistException(typeof(DisplayEntityAttribute).ToString());
            this.DisplayEntity = (DisplayEntityAttribute)ls_attribut[0];
            if (this.DisplayEntity.DisplayMember == null)
                throw new DisplayMember_NotExist_In_DisplayEntityAttribute_Exception("DisplayMember not exist in " + typeof(DisplayEntityAttribute).ToString() + " : " + this.TypeOfEntity.Name);
            if (this.DisplayEntity.Localizable)
            {
                // set all attribute Localizable
                this.Localizable = this.DisplayEntity.Localizable;

                // Titre
                this.DisplayEntity.PluralName = this.GetStringFromRessource(nameof(this.DisplayEntity.PluralName), true);
                this.DisplayEntity.SingularName = this.GetStringFromRessource(nameof(this.DisplayEntity.SingularName), true);


            }
            if (this.DisplayEntity.SingularName == null)
            {
                this.DisplayEntity.SingularName = this.CultureInfo.TwoLetterISOLanguageName + "_" + this.TypeOfEntity.Name;
                this.DisplayEntity.PluralName = this.CultureInfo.TwoLetterISOLanguageName + "_" + PluralizationService
                                                 .CreateService(new CultureInfo("en")).Pluralize(this.TypeOfEntity.Name);
            }
            #endregion

            #region  Read : ManagementFormAttribute
            ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(ManagementFormAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0) this.ManagementForm = new ManagementFormAttribute();
            else this.ManagementForm = (ManagementFormAttribute)ls_attribut[0];
            if (this.Localizable)
            {
                if (this.ManagementForm.TitrePageGridView != null)
                    this.ManagementForm.TitrePageGridView = GetStringFromRessource(this.ManagementForm.TitrePageGridView);
                if (this.ManagementForm.FormTitle != null)
                    this.ManagementForm.FormTitle = GetStringFromRessource(this.ManagementForm.FormTitle);
            }
            if (this.ManagementForm.TitrePageGridView == null)
                this.ManagementForm.TitrePageGridView = this.DisplayEntity.PluralName;
            if (this.ManagementForm.FormTitle == null)
                this.ManagementForm.FormTitle = baseEntityResourceManager
                .GetString("management_of", this.CultureInfo) + " " + this.DisplayEntity.PluralName?.ToLower();

            #endregion

            #region Read  AddButtonAttribute
            ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(AddButtonAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0)
            {
                this.AddButton = new AddButtonAttribute();

            }
            else this.AddButton = (AddButtonAttribute)ls_attribut[0];
            if (this.Localizable)
            {
                if (this.AddButton.Title != null)
                    this.AddButton.Title = GetStringFromRessource(this.AddButton.Title);
            }
            if (this.AddButton.Title == null)
            {
                switch (this.CultureInfo.TwoLetterISOLanguageName)
                {
                    case "fr":
                        this.AddButton.Title = baseEntityResourceManager
                    .GetString("Add", this.CultureInfo) + " " + (this.DisplayEntity.isMaleName ? "un" : "une") + " " + this.DisplayEntity.SingularName.ToLower();
                        break;
                    default:
                        this.AddButton.Title = baseEntityResourceManager
                  .GetString("Add", this.CultureInfo) + " " + this.DisplayEntity.SingularName;
                        break;

                }
            }


            #endregion

            #region Read  Menu 
            ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(MenuAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0) this.Menu = new MenuAttribute();
            else this.Menu = (MenuAttribute)ls_attribut[0];
            if (this.Localizable)
            {
                if (this.Menu.Title != null)
                    this.Menu.Title = GetStringFromRessource(this.Menu.Title);
            }
            if (this.Menu.Title == null || this.Menu.Title == string.Empty)
            {
                this.Menu.Title = this.ManagementForm.FormTitle;
            }

            #endregion
        }

        /// <summary>
        /// Get translated string from resource file
        /// if the string not exist is retrun string source with prefix language 
        /// </summary>
        /// <param name="key">the string to be translated</param>
        /// <param name="return_null_if_nat_exist">determine the return value type</param>
        /// <returns>The translated string or Null if return_null_if_nat_exist is true </returns>
        private string GetStringFromRessource(string key, bool return_null_if_nat_exist = false)
        {
            string msg = null;
            
            foreach (var item in RessourcesManagers.Values)
            {
                string text;
                text = item.GetString(key, this.CultureInfo);
                if (text != null)
                {
                    msg = text;
                    break;
                }
            }

            if (msg == null && !return_null_if_nat_exist)
                msg = this.CultureInfo.Name + "_" + key;
            return msg;
        }

        public void Dispose()
        {
            ConfigEntity.SingletonPerTypeValues.Remove(this.GetType());
        }
    }
}

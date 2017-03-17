
using App.Gwin.Entities;
using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Design.PluralizationServices;
using System.Threading;
using System.Collections.Generic;
using App.Gwin.Shared.Resources;
using App.Gwin.Application.Presentation.Messages;
using App.Gwin.Entities.Resources.Glossary;
using App.Gwin.Exceptions.Gwin;
using App.Gwin.DataModel.Helpers;

namespace App.Gwin.Attributes
{
    /// <summary>
    /// Read Entity configuration
    /// </summary>
    public class ConfigEntity
    {
        #region Public Properties
        public GwinEntityAttribute DisplayEntity { set; get; }
        public ManagementFormAttribute ManagementForm { set; get; }
        public AddButtonAttribute AddButton { set; get; }
        public MenuAttribute Menu { set; get; }
   
        public Type TypeOfEntity { set; get; }
        public bool Localizable { get; set; }
        /// <summary>
        /// Culture Info
        /// </summary>
        public CultureInfo CultureInfo { get;  set; }
        /// <summary>
        /// Entity Ressource manager
        /// </summary>
        public Dictionary<string, ResourceManager> RessourcesManagers { get; private set; }

        ResourceManager baseEntityResourceManager = null;

        private static Dictionary<Type,ConfigEntity> ConfigurationOfEntities { get; set; }
        #endregion


        private ConfigEntity(Type type_of_entity)
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
            if (ConfigurationOfEntities == null)
                ConfigurationOfEntities = new Dictionary<Type, ConfigEntity>();

            if (!ConfigurationOfEntities.Keys.Contains(type_of_entity))
                ConfigurationOfEntities[type_of_entity] = new ConfigEntity(type_of_entity);
         
            return ConfigurationOfEntities[type_of_entity];
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
            // 
            // Read Disply Entity Configuration
            //

            // Load and Check Existance of DisplayEntityAttribute
            Object[] ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(GwinEntityAttribute), false);
            if (ls_attribut == null || ls_attribut.Count() == 0)
            {
                string msg_excepion = "The meta annotation :" + nameof(GwinEntityAttribute) + " not exist ";
                msg_excepion += " in Entity : " + this.TypeOfEntity.Name;
                msg_excepion += ". It is required, because it contain DiplayMameber config that is used by ToString method to diply Entity";
                throw new GwinException(msg_excepion); 
            }

            this.DisplayEntity = (GwinEntityAttribute)ls_attribut[0];

            // Check DisplayMember existance
            if (this.DisplayEntity.DisplayMember == null)
                throw new DisplayMember_NotExist_In_DisplayEntityAttribute_Exception("DisplayMember not exist in " + typeof(GwinEntityAttribute).ToString() + " : " + this.TypeOfEntity.Name);
            if (this.DisplayEntity.Localizable)
            {
                // set all attribute Localizable
                this.Localizable = this.DisplayEntity.Localizable;

                // Titre
                this.DisplayEntity.PluralName = this.GetStringFromRessource("PluralName", true);
                this.DisplayEntity.SingularName = this.GetStringFromRessource("SingularName", true);

                // Load Title with Name of Entity if PluraleNameKay Not exist
                if(this.DisplayEntity.PluralName == null)
                    this.DisplayEntity.PluralName = this.GetStringFromRessource(this.TypeOfEntity + "_PluraleName", false);
                if (this.DisplayEntity.SingularName == null)
                    this.DisplayEntity.SingularName = this.GetStringFromRessource(this.TypeOfEntity +"_SingularName", false);



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
                        this.AddButton.Title = Glossary.Add  + " " + (this.DisplayEntity.isMaleName ? "un" : "une") + " " + this.DisplayEntity.SingularName.ToLower();
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

        public bool Dispose()
        {
           return ConfigEntity.ConfigurationOfEntities.Remove(this.TypeOfEntity);
        }
        /// <summary>
        /// Delete all ConfigEntity object
        /// </summary>
        internal static void Despose()
        {
            ConfigurationOfEntities.Clear();
        }
    }
}

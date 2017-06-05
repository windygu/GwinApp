
using GApp.GwinApp.Entities;
using GApp.GwinApp.Entities.Resources.Glossary;
using GApp.GwinApp.Exceptions.Gwin;
using GApp.GwinApp.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace GApp.GwinApp.Attributes
{
    /// <summary>
    /// Entity schema configuration
    /// </summary>
    public class ConfigEntity
    {
 
        #region Attributes Instance  
        public GwinEntityAttribute GwinEntity { set; get; }
        public ManagementFormAttribute ManagementForm { set; get; }
        public AddButtonAttribute AddButton { set; get; }
        public MenuAttribute Menu { set; get; }
        public List<DataGridSelectedActionAttribute> ListDataGridSelectedAction { set; get; }
        public GwinFormAttribute GwinForm { get; set; }
        public SelectionCriteriaAttribute SelectionCriteria { set; get; }
        public PresentationLogicAttribute PresentationLogic { get; set; }
        #endregion


        #region Presentation Variables
        /// <summary>
        /// Culture Info
        /// </summary>
        public CultureInfo CultureInfo { get; set; }
        /// <summary>
        /// Entity Ressource manager
        /// </summary>
        public Dictionary<string, ResourceManager> RessourcesManagers { get; set; }

        ResourceManager baseEntityResourceManager = null;
        #endregion

        #region Business Variables
        /// <summary>
        /// Type of Entity 
        /// </summary>
        public Type TypeOfEntity { set; get; }
        /// <summary>
        /// Indicate if the entity is localizable
        /// </summary>
        public bool Localizable { get; set; }
   
        #endregion

        #region Data Variables
        /// <summary>
        /// List of Configuration instances, its saves to minim time of traitement
        /// </summary>
        private static Dictionary<Type, ConfigEntity> ConfigurationOfEntities { get; set; }
        #endregion


        private ConfigEntity(Type type_of_entity)
        {
            this.TypeOfEntity = type_of_entity;
            this.CultureInfo = Thread.CurrentThread.CurrentCulture;

            // Create Attribute Instances
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
        /// 
        /// </summary>
        private void LoadRessouce()
        {
            //Fill RessouceManager
            this.RessourcesManagers = new Dictionary<string, ResourceManager>();
            RessoucesManagerHelper.FillResourcesManager(this.TypeOfEntity, this.RessourcesManagers);

            // BaseEntity RessouceManager
            string BaseEntityRessouceFullName = typeof(BaseEntity).Namespace + ".Resources." + typeof(BaseEntity).Name + "." + typeof(BaseEntity).Name;
            baseEntityResourceManager = new ResourceManager(BaseEntityRessouceFullName, typeof(BaseEntity).Assembly);
        }

        /// <summary>
        /// Read configuration of entity
        /// </summary>
        private void ReadConfiguration()
        {

            this.LoadRessouce();

            

            #region Read GwinForm 
            Object[] ls_attribut_GwinForm = this.TypeOfEntity.GetCustomAttributes(typeof(GwinFormAttribute), false);
            if (ls_attribut_GwinForm != null && ls_attribut_GwinForm.Count() > 0)
                this.GwinForm = (GwinFormAttribute)ls_attribut_GwinForm[0];
            #endregion

            #region Load PresentationLogic
            Object[] ls_PresentationLogic = this.TypeOfEntity.GetCustomAttributes(typeof(PresentationLogicAttribute), false);
            if (ls_PresentationLogic != null && ls_PresentationLogic.Count() > 0)
                this.PresentationLogic = (PresentationLogicAttribute)ls_PresentationLogic[0];
            #endregion

            #region Read DisplayEntityAttribute
            // 
            // Read GwinEntity  Configuration
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

            this.GwinEntity = (GwinEntityAttribute)ls_attribut[0];

            // Check DisplayMember existance
            if (this.GwinEntity.DisplayMember == null)
                throw new DisplayMember_NotExist_In_DisplayEntityAttribute_Exception("DisplayMember not exist in " + typeof(GwinEntityAttribute).ToString() + " : " + this.TypeOfEntity.Name);
            if (this.GwinEntity.Localizable)
            {
                // set all attribute Localizable
                this.Localizable = this.GwinEntity.Localizable;

                // Titre
                this.GwinEntity.PluralName = this.GetStringFromRessource("PluralName", true);
                this.GwinEntity.SingularName = this.GetStringFromRessource("SingularName", true);

                // Load Title with Name of Entity if PluraleNameKay Not exist
                if (this.GwinEntity.PluralName == null)
                    this.GwinEntity.PluralName = this.GetStringFromRessource(this.TypeOfEntity + "_PluraleName", false);
                if (this.GwinEntity.SingularName == null)
                    this.GwinEntity.SingularName = this.GetStringFromRessource(this.TypeOfEntity + "_SingularName", false);



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

            if (this.ManagementForm.FormTitle == null)
                this.ManagementForm.FormTitle = Glossary.management_of + " " + this.GwinEntity.PluralName?.ToLower();
            if (this.ManagementForm.TitrePageGridView == null)
                this.ManagementForm.TitrePageGridView = this.ManagementForm.FormTitle;

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
                        this.AddButton.Title = Glossary.Add + " " + (this.GwinEntity.isMaleName ? "un" : "une") + " " + this.GwinEntity.SingularName.ToLower();
                        break;
                    default:
                        this.AddButton.Title = baseEntityResourceManager
                  .GetString("Add", this.CultureInfo) + " " + this.GwinEntity.SingularName;
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

            #region Read DataGridSelectedAction
            ls_attribut = this.TypeOfEntity.GetCustomAttributes(typeof(DataGridSelectedActionAttribute), false);
            if (ls_attribut != null)
                this.ListDataGridSelectedAction = ls_attribut.OfType<DataGridSelectedActionAttribute>().ToList();
            if (this.Localizable)
            {
                foreach (var item in this.ListDataGridSelectedAction)
                {
                    if (item.Title != null)
                        item.Title = GetStringFromRessource(item.Title);
                    if (item.Description != null)
                        item.Description = GetStringFromRessource(item.Description);
                }
            }

            // if Text is null; we use form.Text
            foreach (var item in this.ListDataGridSelectedAction)
            {
                if (item.TypeOfForm == null)
                    throw new GwinException(string.Format("The TypeOfFrom of DataGridSelectedAction in Entity :{0} must not be null,it is used to Create Instance of Form to execute traitement action", this.TypeOfEntity.FullName));
                if (item.Title == null || item.Title == string.Empty)
                {
                    Form form = Activator.CreateInstance(item.TypeOfForm) as Form;
                    item.Title = form.Text;
                }
            }
            #endregion

            #region Read SelectionCriteria
            Object[] ls_attribut_SelectionCriteria = this.TypeOfEntity.GetCustomAttributes(typeof(SelectionCriteriaAttribute), false);
            if (ls_attribut_SelectionCriteria != null && ls_attribut_SelectionCriteria.Count() > 0)
                this.SelectionCriteria = (SelectionCriteriaAttribute)ls_attribut_SelectionCriteria[0];

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

        /// <summary>
        /// Translate Msg 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Translate(string msg)
        {
            string translated_msg = this.GetStringFromRessource(msg);
            return translated_msg;
        }

        public bool Dispose()
        {
            return ConfigEntity.ConfigurationOfEntities.Remove(this.TypeOfEntity);
        }
        /// <summary>
        /// Delete all ConfigEntity object
        /// </summary>
        public static void Despose()
        {
            if (ConfigurationOfEntities != null)
                ConfigurationOfEntities.Clear();
        }
    }
}

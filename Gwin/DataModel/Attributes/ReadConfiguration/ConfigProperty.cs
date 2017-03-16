using App.Gwin;
using App.Gwin.Application;
using App.Gwin.Application.Presentation.Messages;
using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Shared.Resources;
using App.Gwin.Entities.Resources.Glossary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.FieldsTraitements.Enumerations;
using App.Gwin.Exceptions.Gwin;

namespace App.Shared.AttributesManager
{
    /// <summary>
    /// Read Property Configuration
    /// </summary>
    public class ConfigProperty
    {
        #region Public Properties
        public DisplayPropertyAttribute DisplayProperty { set; get; }
        public RelationshipAttribute Relationship { set; get; }
        public EntryFormAttribute EntryForm { set; get; }
        public FilterAttribute Filter { set; get; }
        public DataGridAttribute DataGrid { set; get; }
        public DataSourceAttribute DataSource { set; get; }
        public FieldsNatures FieldNature { set; get; }
        public PropertyInfo PropertyInfo { get; set; }
        public ConfigEntity ConfigEntity { get; set; }
        public Type TypeOfEntity { set; get; }
        public bool Localizable { get;   set; }
        public CultureInfo CultureInfo { get;   set; }
       
        /// <summary>
        ///  Resource Manager of the Entity and its BaseType
        /// </summary>
        Dictionary<string, ResourceManager> RessoucesManagers = new Dictionary<string, ResourceManager>();
        #endregion

        public ConfigProperty(PropertyInfo propertyInfo, ConfigEntity configEntity)
        {

            this.PropertyInfo = propertyInfo;


            this.ConfigEntity = configEntity;
            //Fill RessouceManager
            this.RessoucesManagers = this.ConfigEntity.RessourcesManagers;


            // Culture Info
            this.CultureInfo = GwinApp.Instance.CultureInfo;

            // Localizable
            this.TypeOfEntity = propertyInfo.ReflectedType;
            this.Localizable = this.ConfigEntity.DisplayEntity.Localizable;

            //
            // Relationship
            //
            Attribute Relationship = propertyInfo.GetCustomAttribute(typeof(RelationshipAttribute));
            this.Relationship = Relationship as RelationshipAttribute;
            if(this.Relationship != null)
            {
                // Check if Type of Memeber is valide Generic List
                if (
                    (this.Relationship.Relation == RelationshipAttribute.Relations.ManyToMany_Creation
                    || this.Relationship.Relation == RelationshipAttribute.Relations.ManyToMany_Selection
                    || this.Relationship.Relation == RelationshipAttribute.Relations.OneToMany) 
                    &&
                    this.PropertyInfo.PropertyType.GetGenericArguments().Count() == 0)
                {
                    string msg_exception = "The Type :" + this.PropertyInfo.PropertyType.Name;
                    msg_exception += " of member " + this.PropertyInfo.Name;
                    msg_exception += " in Entity " + this.PropertyInfo.DeclaringType.Name;
                    msg_exception += " is not a valid generic List";
                    throw new GwinException(msg_exception);
                }
            }

            //
            // DisplayProperty
            //
            #region DisplayProperty
            // Load DisplayProperty
            Attribute DisplayProperty = propertyInfo.GetCustomAttribute(typeof(DisplayPropertyAttribute));
            this.DisplayProperty = DisplayProperty as DisplayPropertyAttribute;
            // If DisplayProperty not exist
            if (this.DisplayProperty == null)
            {
                if (this.Localizable == false)
                    throw new AnnotationNotExistException("DisplayPropertyAttribute :" + propertyInfo.ToString());
                this.DisplayProperty = new DisplayPropertyAttribute();
            }
            if (this.DisplayProperty.isInGlossary)
            {
                string GlossaryRessouceFullName = "App.Gwin.Entities.Resources.Glossary.Glossary";
                ResourceManager GlossaryResourceManager = null;
                GlossaryResourceManager = new ResourceManager(GlossaryRessouceFullName, typeof(Glossary).Assembly);
                string title = GlossaryResourceManager.GetString(propertyInfo.Name, this.CultureInfo);
                if (title == null)
                    this.DisplayProperty.Titre = this.CultureInfo.Name + "_Glossary_" + propertyInfo.Name;
                else
                    this.DisplayProperty.Titre = title;
            }
            else
            {
                //
                // Title
                //
                if (this.DisplayProperty.Titre == null)
                {
                    
                    if ( this.PropertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntity)))
                        this.DisplayProperty.Titre = ConfigEntity.CreateConfigEntity(this.PropertyInfo.PropertyType).DisplayEntity.SingularName;
                    else
                        this.DisplayProperty.Titre = GetStringFromRessource(propertyInfo.Name);
                }
                else
                    this.DisplayProperty.Titre = GetStringFromRessource(propertyInfo.Name);
            }
            #endregion

            //
            // EntryForm
            //
            Attribute EntryForm = propertyInfo.GetCustomAttribute(typeof(EntryFormAttribute));
            this.EntryForm = EntryForm as EntryFormAttribute;

            //
            // DataGrid
            //
            Attribute DataGrid = propertyInfo.GetCustomAttribute(typeof(DataGridAttribute));
            this.DataGrid = DataGrid as DataGridAttribute;
            // Order 
            if (this.EntryForm != null && this.EntryForm.Ordre > 0
                && this.DataGrid != null && this.DataGrid.Ordre == 0)
                this.DataGrid.Ordre = this.EntryForm.Ordre;

            //
            // Filter
            //
            Attribute Filter = propertyInfo.GetCustomAttribute(typeof(FilterAttribute));
            this.Filter = Filter as FilterAttribute;

            //
            // DataSource
            //
            Attribute dataSource = propertyInfo.GetCustomAttribute(typeof(DataSourceAttribute));
            this.DataSource = dataSource as DataSourceAttribute;

            // Determine FieldNautre
            this.DetermineFieldNature();

        }

        /// <summary>
        /// Determine FieldNature
        /// </summary>
        private void DetermineFieldNature()
        {
            
            if (this.PropertyInfo.PropertyType.Name == "String" && this.DataSource == null)
            {
                this.FieldNature = FieldsNatures.String;
                return;
            }
            if (this.PropertyInfo.PropertyType.Name == "String" && this.DataSource != null)
            {
                this.FieldNature = FieldsNatures.StringWithDataSource;
                return;
            }
            if (this.PropertyInfo.PropertyType.Name == "LocalizedString")
            {
                this.FieldNature = FieldsNatures.LocalizedString;
                return;
            }
            if (this.PropertyInfo.PropertyType.Name == "Int32")
            {
                this.FieldNature = FieldsNatures.Int32;
                return;
            }
            if (this.PropertyInfo.PropertyType.Name == "DateTime")
            {
                this.FieldNature = FieldsNatures.DateTime;
                return;

            }
            if (this.PropertyInfo.PropertyType.IsEnum)
            {
                this.FieldNature = FieldsNatures.Enumeration;
                return;
            }
            if (this.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
            {
                this.FieldNature = FieldsNatures.ManyToOne;
                return;
            }
            if (this.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany_Selection)
            {
                this.FieldNature = FieldsNatures.ManyToMany_Selection;
                return;
            }
        }



        private string GetStringFromRessource(string key, bool return_null_if_nat_exist = false)
        {
            string msg = null;
            foreach (var item in RessoucesManagers.Values)
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
    }
}

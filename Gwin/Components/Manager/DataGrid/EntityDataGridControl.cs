using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using App.Gwin.Attributes;
using App.Shared.AttributesManager;
using App.Gwin.Entities;
using System.Resources;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.Application.BAL;
using App.Gwin.Components.Manager.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements;
using App.Gwin.Exceptions.Gwin;
using App.Gwin.Exceptions.Helpers;

namespace App.Gwin
{
    public partial class EntityDataGridControl : UserControl, IEntityDataGrideControl
    {
        #region Properties
        /// <summary>
        /// Selected Entity in DataGrid
        /// </summary>
        public BaseEntity SelectedEntity
        {
            get
            {
                return this.ObjetBindingSource.Current as BaseEntity;
            }
        }
        /// <summary>
        ///  ??
        /// </summary>
        public PropertyInfo SelectedProperty { set; get; }

        /// <summary>
        /// EtityBLO Instance
        /// </summary>
        public IGwinBaseBLO EntityBLO { set; get; }

        /// <summary>
        /// FilterValues : Key : String, Value :Object
        /// Key : Property name, Value : Entity ID
        /// </summary>
        public Dictionary<string, object> FilterValues { set; get; }

        /// <summary>
        /// List of  Property taht can be shown in DataGrid
        /// </summary>
        public List<PropertyInfo> ListeProprieteDataGrid { set; get; }

        /// <summary>
        /// Entity config instance
        /// </summary>
        public ConfigEntity ConfigEntity { get;  set; }
        #endregion

        #region Evénement
        /// <summary>
        /// Edit Click event
        /// </summary>
        public event EventHandler EditClick;
        protected void onEditClick(object sender, EventArgs e)
        {
            if (EditClick != null)
                EditClick(sender, e);
        }

        /// <summary>
        /// Get DataGrid View Instance 
        /// Used to Test Control
        /// </summary>
        public DataGridView GetDataGridViewInstance()
        {
            return this.dataGridView;
        }

        /// <summary>
        /// Edit Many to one click event
        /// </summary>
        public event EventHandler EditManyToOneCollection;
        protected void onEditManyToOneCollection(object sender, EventArgs e)
        {

            if (EditManyToOneCollection != null)
                EditManyToOneCollection(sender, e);
        }
        /// <summary>
        /// Edit Many to Many click event
        /// </summary>
        public event EventHandler EditManyToManyCollection;
        protected void onEditManyToManyCollection(object sender, EventArgs e)
        {
            if (EditManyToManyCollection != null)
                EditManyToManyCollection(sender, e);
        }

        /// <summary>
        /// Refresh Event
        /// </summary>
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Create EntityDataGrid Instance
        /// </summary>
        /// <param name="EtityBLO"></param>
        /// <param name="FilterValues"></param>
        public EntityDataGridControl(IGwinBaseBLO EtityBLO, Dictionary<string, object> FilterValues)
        {
            InitializeComponent();

            CheckPramIsNull.CheckParam_is_NotNull(EtityBLO, this, nameof(EtityBLO));


            this.EntityBLO = EtityBLO;
            this.ConfigEntity = ConfigEntity.CreateConfigEntity(this.EntityBLO.TypeEntity);
            this.FilterValues = FilterValues;

            // List of Property with DataGrid Annotation
            var requete = from i in EntityBLO.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(DataGridAttribute)) != null
                          orderby ((DataGridAttribute)i.GetCustomAttribute(typeof(DataGridAttribute))).Ordre
                          select i;
            this.ListeProprieteDataGrid = requete.ToList<PropertyInfo>();

            InitDataGridView();
        }
        /// <summary>
        /// You can not use this constuctor to create EntityDataGrid Instance
        /// It is used en to support DesinMode en Visaul Sutdio
        /// </summary>
        public EntityDataGridControl()  {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                throw new GwinUsageModeException("This constructor is used just for DesineMode in Visal Studio, you can not use it per Code");
            InitializeComponent();
        }
        #endregion

        #region Refresh
        /// <summary>
        /// Show Entity List in DataGrid, With Intial FilterValues
        /// </summary> 
        public void RefreshEntities()
        {
            this.RefreshEntities(this.FilterValues);
        }
        /// <summary>
        /// Show Entity List in DataGrid with FilterValues
        /// </summary>
        /// <param name="FilterValues">Filter Values to filter Data in GridView</param>
        public void RefreshEntities(Dictionary<string, object> FilterValues)
        {
            
            this.FilterValues = FilterValues;
            var ls = EntityBLO.Recherche(FilterValues);

            ObjetBindingSource.Clear();
            foreach (var item in ls)
            {
                ObjetBindingSource.Add(item);
            }
           
            
        }
        #endregion

        #region Insert Column in DataGrid


        /// <summary>
        /// Insert Column in DataGrid
        /// </summary>
        private void InitDataGridView()
        {
            int index_colonne = 0;

            foreach (PropertyInfo propertyInfo in this.ListeProprieteDataGrid)
            {

                ConfigProperty configProperty = new ConfigProperty(propertyInfo, this.ConfigEntity);

                ////  Ordre column
                //if (propertyInfo.Name == nameof(BaseEntity.Ordre) && this.ConfigEntity.ManagementForm?.isDisplayWithOrder == false)
                //    continue;

                // Not show Collection if not have relationship : ManyToMany_Creation
                //if (propertyInfo.PropertyType.Name == "List`1" &&
                //    configProperty.Relationship?.Relation != RelationshipAttribute.Relations.ManyToMany_Creation)
                //    continue;

              
                // Insertion des la colonne selon le tupe de la propriété
                DataGridViewColumn colonne = new DataGridViewTextBoxColumn(); ;
                index_colonne++;


                // Params to Creat Fields
                CreateFieldColumns_In_EntityDataGrid param = new CreateFieldColumns_In_EntityDataGrid();
                param.Column = colonne;
                param.ConfigProperty = configProperty;
                // Create FieldTraitement Instance
                IFieldTraitements fieldTraitement = BaseFieldTraitement.CreateInstance(configProperty);

                // Invok Create Column 
                fieldTraitement.ConfigFieldColumn_In_EntityDataGrid(param);

                // Insert Column in DataGriView
                this.dataGridView.Columns.Insert(index_colonne, colonne);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseEntity obj = (BaseEntity)ObjetBindingSource.Current;
            // Supprimer
            if (e.ColumnIndex == dataGridView.Columns["Supprimer"].Index && e.RowIndex >= 0)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Voullez-vous vraimment supprimer :" + obj.ToString(),
                    "Confirmation de supprision", MessageBoxButtons.YesNo))
                {
                    this.EntityBLO.Delete(obj);
                    this.RefreshEntities();
                }
            }
            // Editer
            if (e.ColumnIndex == dataGridView.Columns["Editer"].Index && e.RowIndex >= 0)
            {
                onEditClick(this, null);
            }



            foreach (var item in this.ListeProprieteDataGrid.Where(p => p.PropertyType.Name == "List`1"))
            {
                ConfigProperty attributesOfProperty = new ConfigProperty(item, this.ConfigEntity);
                if (attributesOfProperty.Relationship.Relation != RelationshipAttribute.Relations.ManyToMany_Creation)
                    continue;
                if (e.ColumnIndex == dataGridView.Columns[item.Name].Index && e.RowIndex >= 0)
                {
                    this.SelectedProperty = item;
                    onEditManyToOneCollection(this, e);
                }

            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                onEditClick(this, null);
            }
        }

        #endregion
    }
}

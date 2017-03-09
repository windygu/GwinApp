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

namespace App.Gwin
{
    public partial class EntityDataGridControl : UserControl, IEntityDataGrideControl
    {


        #region Propriétés
        public BaseEntity SelectedEntity
        {

            get
            {
                return this.ObjetBindingSource.Current as BaseEntity;
            }
        }


        public PropertyInfo SelectedProperty { set; get; }
        #endregion

        #region Params

        /// <summary>
        /// Le service de l'entité en gestion  
        /// </summary>
        protected IBaseBLO Service { set; get; }


        /// <summary>
        /// Critère de filtre de recherche
        /// </summary>
        protected Dictionary<string, object> CritereRechercheFiltre { set; get; }

        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListeProprieteDataGrid { set; get; }
        public ConfigEntity ConfigEntity { get; private set; }
        #endregion


        #region Evénement
        /// <summary>
        /// Lancer aprés un click sur éditer
        /// </summary>
        public event EventHandler EditClick;
        protected void onEditClick(object sender, EventArgs e)
        {
            if (EditClick != null)
                EditClick(sender, e);
        }

        public event EventHandler EditManyToOneCollection;
        protected void onEditManyToOneCollection(object sender, EventArgs e)
        {

            if (EditManyToOneCollection != null)
                EditManyToOneCollection(sender, e);
        }


        public event EventHandler EditManyToManyCollection;
        protected void onEditManyToManyCollection(object sender, EventArgs e)
        {

            if (EditManyToManyCollection != null)
                EditManyToManyCollection(sender, e);
        }


        public event EventHandler RefreshEvent;


        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }


        #endregion

        #region Constructeurs

        public EntityDataGridControl(IBaseBLO Service, Dictionary<string, object> critereRechercheFiltre = null)
        {
            InitializeComponent(); if (this.DesignMode) return;
            this.Service = Service;
            this.ConfigEntity = ConfigEntity.CreateConfigEntity(this.Service.TypeEntity);
            this.CritereRechercheFiltre = critereRechercheFiltre;
            InitDataGridView();
        }
        public EntityDataGridControl() : this(null) { }
        #endregion

        #region Actualiser
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            this.Actualiser(this.CritereRechercheFiltre);
        }
        public void Actualiser(Dictionary<string, object> CritereRechercheFiltre)
        {
            ObjetBindingSource.Clear();
            this.CritereRechercheFiltre = CritereRechercheFiltre;
            var ls = Service.Recherche(CritereRechercheFiltre);
            ObjetBindingSource.DataSource = ls;
        }

        #endregion

        #region InitDisingeDataGrid


        /// <summary>
        /// Insert Column in DataGrid
        /// </summary>
        private void InitDataGridView()
        {

            // List of Property with DataGrid Annotation
            var requete = from i in Service.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(DataGridAttribute)) != null
                          orderby ((DataGridAttribute)i.GetCustomAttribute(typeof(DataGridAttribute))).Ordre
                          select i;
            this.ListeProprieteDataGrid = requete.ToList<PropertyInfo>();


            int index_colonne = 0;

            foreach (PropertyInfo propertyInfo in this.ListeProprieteDataGrid)
            {
                ConfigProperty configProperty = new ConfigProperty(propertyInfo, this.ConfigEntity);

                //  Ordre column
                if (propertyInfo.Name == nameof(BaseEntity.Ordre) && this.ConfigEntity.ManagementForm?.isDisplayWithOrder == false)
                    continue;

                // Not show Collection if not have relationship : ManyToMany_Creation
                if (propertyInfo.PropertyType.Name == "List`1" &&
                    configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany_Creation)
                    continue;

              
                // Insertion des la colonne selon le tupe de la propriété
                DataGridViewColumn colonne = new DataGridViewTextBoxColumn(); ;
                index_colonne++;

               

                if (propertyInfo.PropertyType.Name == "String")
                {
                    colonne.ValueType = typeof(String);
                    colonne.DataPropertyName = propertyInfo.Name;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    colonne.ReadOnly = true;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);

                    continue;
                }
                // [Bug] Change static string to Variable nameof
                if (propertyInfo.PropertyType.Name == "LocalizedString")
                {
                    colonne.ValueType = typeof(LocalizedString);
                    colonne.DataPropertyName = propertyInfo.Name;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    colonne.ReadOnly = true;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);
                    continue;
                }

                if (propertyInfo.PropertyType.Name == "Integer")

                {
                    colonne.ValueType = typeof(String);
                    colonne.DataPropertyName = propertyInfo.Name;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    colonne.ReadOnly = true;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);
                    continue;
                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    colonne = new DataGridViewTextBoxColumn();
                    colonne.ValueType = typeof(DateTime);
                    colonne.DataPropertyName = propertyInfo.Name;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    colonne.ReadOnly = true;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);
                    continue;
                }

                if (propertyInfo.PropertyType.IsEnum)
                {
                    colonne.ValueType = propertyInfo.PropertyType;
                    colonne.DataPropertyName = propertyInfo.Name;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    colonne.ReadOnly = true;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);

                    continue;
                }

                if (configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany_Creation)
                {
                    DataGridViewButtonColumn c = new DataGridViewButtonColumn();
                    c.UseColumnTextForButtonValue = true;
                    c.Text = propertyInfo.Name;
                    colonne = c;
                    colonne.ReadOnly = true;
                    colonne.HeaderText = configProperty.DisplayProperty.Titre;
                    colonne.Name = propertyInfo.Name;
                    if (configProperty.DataGrid?.WidthColonne != 0) colonne.Width = configProperty.DataGrid.WidthColonne;
                    this.dataGridView.Columns.Insert(index_colonne, colonne);
                    continue;
                }

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
                    this.Service.Delete(obj);
                    this.Actualiser();
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

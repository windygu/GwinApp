﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using App.Gwin.Attributes;
using System.Reflection;
using App.Gwin.Entities;
using App.Gwin.Application.Presentation.EntityManagement;
using App.Gwin.Application.Presentation;
using App.Gwin.Application.BAL;

namespace App.Gwin.EntityManagement
{
    public partial class BaseEntityTabControl : UserControl
    {

        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IGwinBaseBLO Service { set; get; }

        /// <summary>
        /// Instance de filtre controle
        /// </summary>
        protected BaseFilterControl BaseFilterControl { set; get; }

        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseEntryForm Formulaire { set; get; }

        /// <summary>
        /// La formulaire MdiParent de l'application
        /// il est utiliser pour afficher une interface de gestion
        /// </summary>
        protected Form MdiParent { set; get; }
        

        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListePropriete { set; get; }
        #endregion

        #region Controls
        /// <summary>
        /// L'objet Binding source la classe hérité
        /// </summary>
        protected BindingSource BaseObjetBindingSource { set; get; }

        /// <summary>
        /// L'objet DataGrid de la classe hérité
        /// </summary>
        protected DataGridView BaseDataGridView { set; get; }
        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeur
        public BaseEntityTabControl()
        {
            InitializeComponent();
            
        }
        public BaseEntityTabControl(IGwinBaseBLO Service,BaseFilterControl BaseFilterControl,Form MdiParent, BaseEntryForm Formulaire)
        {
            InitializeComponent();
            this.Service = Service;
            this.BaseFilterControl = BaseFilterControl;
            this.MdiParent = MdiParent;
            this.Formulaire = Formulaire;
            InitPropertyListDataGrid();
        }

        [Obsolete]
        protected void InitPropertyListDataGrid()
        {
            // [Bug]
            // Ajoutez la condition filtre 
            var requete = from i in Service.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(DataGridAttribute)) != null 
                          orderby ((DataGridAttribute)i.GetCustomAttribute(typeof(DataGridAttribute))).Ordre
                          select i;
            this.ListePropriete = requete.ToList<PropertyInfo>();
        }

        #endregion

    }
}

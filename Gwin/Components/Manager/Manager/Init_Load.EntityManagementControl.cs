using App.Gwin.Attributes;
using App.Gwin.EntityManagement;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Gwin.Shared.Resources;
using System.Resources;

namespace App.Gwin
{
    public partial class EntityManagementControl
    {

        private void EntityManagementForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                this.Actualiser();
        }


        #region Initialisation
        /// <summary>
        /// Initialisation et Création des controles
        /// </summary>
        /// <param name="service"></param>
        /// <param name="formulaire"></param>
        protected void initControls()
        {

            // ConfigEntity
            this.ConfigEntity =  ConfigEntity.CreateConfigEntity(this.Service.TypeEntity);


            //
            // TabControlManager, il contient tous les autres manager
            //
            this.tabControl_MainManager.Dock = DockStyle.Fill;
            this.tabControlManagers.Visible = false;
            this.panelDataGrid.Controls.Add(this.tabControl_MainManager);

            


            //
            // Formulaire
            //
            if (this.Formulaire == null)
                this.Formulaire = new BaseEntryForm(this.Service);
            //
            // Filtre
            //
            if (this.FilterControl == null)
            {
                this.FilterControl = new BaseFilterControl(this.Service, this.ValeursFiltre);
            }
            this.FilterControl.Dock = DockStyle.Fill;
            this.panel_Filtre.Controls.Add(this.FilterControl);
            this.FilterControl.RefreshEvent += BaseFilterControl_RefreshEvent;
          
            //
            // DataGrid
            //
            if (this.DataGridControl == null)
                this.DataGridControl = new EntityDataGridControl(this.Service, this.ValeursFiltre);
            this.DataGridControl.Dock = DockStyle.Fill;
            this.tabControl_MainManager.TabPages["TabGrid"].Controls.Add(this.DataGridControl);
            this.DataGridControl.EditClick += EntityDataGridControl_EditClick;
            this.DataGridControl.EditManyToOneCollection += DataGridControl_EditManyToOneCollection;
            this.DataGridControl.EditManyToManyCollection += DataGridControl_EditManyToManyCollection;
            //
            // Modification des Titre 
            //
            //ManagementFormAttribute managementFormAttribute = this.Service.getManagementFormAttribute();
            
            this.Name = "Interface_Gestion_" + this.Service.TypeEntity.ToString();
            this.Text = this.ConfigEntity.ManagementForm.FormTitle;
            this.tabPageAdd.ToolTipText = this.ConfigEntity.AddButton.Title;
            
            this.tabControl_MainManager.TabPages["TabGrid"].Text = this.ConfigEntity.ManagementForm.TitrePageGridView;

            
        }
        #endregion
    }
}

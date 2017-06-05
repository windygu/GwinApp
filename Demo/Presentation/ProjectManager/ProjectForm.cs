using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GApp.GwinApp;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Entities;
using GApp;
using GenericWinForm.Demo.Entities;
using GApp.GwinApp.Components.Manager.EntryForms.Resources;
using GenericWinForm.Demo.Entities.ProjectManager;

namespace GenericWinForm.Demo.Presentation.ProjectManager
{
    public partial class ProjectForm : BaseEntryForm
    {
        public ProjectForm()
        {
            InitializeComponent();
        }
      

        public ProjectForm(IGwinBaseBLO EtityBLO,
            BaseEntity entity,
            Dictionary<string, object> critereRechercheFiltre,
            bool AutoGenerateField) : base(EtityBLO, entity, critereRechercheFiltre, false)
        {
            InitializeComponent();
        }

        public ProjectForm(IGwinBaseBLO service)
            : this(service, null, null, false) { }



        /// <summary>
        /// Show the Entitu in EntyForm 
        /// </summary>
        /// <param name="CriteriaFilter"></param>
        /// <param name="EntityAction"></param>
        public override void ShowEntity(Dictionary<string, object> CriteriaFilter, EntityActions EntityAction)
        {
            Project project = this.Entity as Project;
            txtText.Text = project.Title;
            txtDescription.Text = project.Description.Current;
        }

        /// <summary>
        /// Read Entity from EntryForm
        /// </summary>
        public override void ReadEntity()
        {
            // Read Entity
            Project project = this.Entity as Project;
            project.Title = txtText.Text;
            project.Description.Current = txtDescription.Text;
        }


        protected override void Save_Click(object sender, EventArgs e)
        {
            // Check is All controls en Form are validate
            if (ValidationManager.hasValidationErrors(this.Controls))
                return;

            
            this.ReadEntity();
         

            // Save
            if (EntityBLO.Save(this.Entity) > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, string.Format(ResourceEntryForm.Entity_has_been_properly_registered, this.Entity.ToString()));
                onEnregistrerClick(this, e);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,
                    string.Format(ResourceEntryForm.The_information_is_not_saved_because_there_are_no_changes
                    , this.Entity.ToString())
                    , ResourceEntryForm.There_are_no_changes
                    );
            }
        }
    }
}

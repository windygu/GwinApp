using App.Gwin.Application.BAL;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenericWinForm.Demo.Presentation.ProjectManager
{
    public partial class ProjectForm : App.Gwin.BaseEntryForm
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




        private void panel_Project_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_form_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

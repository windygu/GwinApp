using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.Presentation.EntityManagement;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.MainForm
{
    public partial class FormApplication : BaseForm, IApplicationMenu
    { 
    
        protected EntityManagementCreator showManagementForm { set; get; }

        protected void InitializeForm()
        {
            InitializeComponent();
            showManagementForm = new EntityManagementCreator(GwinApp.Instance.TypeDBContext, this);
            new ConfigMenuApplication(this);

        }
        public FormApplication()
        {
            InitializeComponent();
        }
        private void FormApplication_Load(object sender, EventArgs e)
        {
           
        }
       
        public MenuStrip getMenuStrip()
        {
            return this.menuStrip1;
        }

        private void frenchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GwinApp.ChangeLanguage(CultureInfo.CreateSpecificCulture("fr"));
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GwinApp.ChangeLanguage(CultureInfo.CreateSpecificCulture("en"));
        }

        private void arabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GwinApp.ChangeLanguage(new CultureInfo("ar"));
        }

       
    }
}

using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Application.Presentation.EntityManagement;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace App.WinForm.Application.Presentation.MainForm
{
    public partial class FormApplication : BaseForm, IApplicationMenu
    { 
    
        protected EntityManagementCreator showManagementForm { set; get; }

        protected void InitializeForm()
        {
            InitializeComponent();
            showManagementForm = new EntityManagementCreator(Gwin.Instance.TypeDBContext, this);
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
            Gwin.ChangeLanguage(CultureInfo.CreateSpecificCulture("fr"));
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gwin.ChangeLanguage(CultureInfo.CreateSpecificCulture("en"));
        }

        private void arabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gwin.ChangeLanguage(new CultureInfo("ar"));
        }

       
    }
}

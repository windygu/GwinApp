using System;
using System.Windows.Forms;
using App.WinFrom.Menu;
using System.Globalization;
using App.WinForm.Security;
using App.WinForm.Entities;
using App.WinForm.Forms;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms.FormMenu;
using App.WinForm.Entities.Application;
using App.WinForm.Application.Security;
using App.WinForm.Application.BAL;
using App;

namespace App
{
    public partial class FormMenu : BaseForm, IApplicationMenu
    {
        public FormMenu()
        {
            User user = new User();
            user.Name = "ES-SARRAJ";
            user.FirstName = "Fouad";

            ApplicationInstance.Session = new Session(this, user, CultureInfo.CreateSpecificCulture("fr"));
            InstallApplication installApplication = new InstallApplication(typeof(ModelContext));
            installApplication.Update();
 
            Reload();
        }
        public override void Reload()
        {
            this.Controls.Clear();
            InitializeComponent();
            AfficherFormulaire = new ShowEntityManagementForm(new BaseBAO<BaseEntity>(), this);
            new ConfigMenuApplication(new BaseBAO<MenuItemApplication>(), this);
        }

        #region IBaseForm
        public MenuStrip getMenuStrip()
        {
            return this.menuStrip1;
        }
       
        #endregion



        ShowEntityManagementForm AfficherFormulaire { set; get; }
        private void binfingNavigatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void FormMenu_Load(object sender, EventArgs e)
        {
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ApplicationInstance.Session.Change_Culture(CultureInfo.CreateSpecificCulture("fr"));
            this.RightToLeftLayout = false;
            this.RightToLeft = RightToLeft.No;

        }

        private void anglaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationInstance.Session.Change_Culture(CultureInfo.CreateSpecificCulture("en"));
            this.RightToLeftLayout = false;
            this.RightToLeft = RightToLeft.No;


        }

        private void arabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationInstance.Session.Change_Culture(new CultureInfo("ar"));
        }
     
    }
}

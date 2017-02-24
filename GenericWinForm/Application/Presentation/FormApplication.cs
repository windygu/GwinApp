using App.WinForm.Application.BAL;
using App.WinForm.Application.Security;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms;
using App.WinForm.Forms.FormMenu;
using App.WinFrom.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Application.Presentation
{
    public partial class FormApplication : BaseForm, IApplicationMenu
    { 
    
        protected ShowEntityManagementForm showManagementForm { set; get; }

        protected void InitializeForm()
        {
            InitializeComponent();
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
            GWinApp.Session.ChangeLanguage(CultureInfo.CreateSpecificCulture("fr"),this);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GWinApp.Session.ChangeLanguage(CultureInfo.CreateSpecificCulture("en"), this);
        }

        private void arabToolStripMenuItem_Click(object sender, EventArgs e)
        {
           GWinApp.Session.ChangeLanguage(new CultureInfo("ar"), this);
        }

       
    }
}

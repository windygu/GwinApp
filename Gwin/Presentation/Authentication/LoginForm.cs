using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.GwinApplication.Presentation.Authentication
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.AcceptButton = loginControl1.GetConnexionButton();
            // Change Form Direction  - When  Languauge is changed
            if (GwinApp.Instance.CultureInfo.TwoLetterISOLanguageName == "fr" || GwinApp.Instance.CultureInfo.TwoLetterISOLanguageName == "en")
            {
                this.RightToLeftLayout = false;
                this.RightToLeft = RightToLeft.No;
            }
            else
            {
                this.RightToLeftLayout = true;
                this.RightToLeft = RightToLeft.Yes;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loginControl1.LoginValide)
                GwinApp.CloseApplication();
        }
    }
}

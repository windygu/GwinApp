using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Gwin.GwinApplication.BLL.Authentication;

namespace App.Gwin.Components.Authentication
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            RememberMeCheckBox.Enabled = false;
           
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {

            if (new AuthenticationBLO().Authentication(LoginTextBox.Text, PasswordTextBox.Text))
                this.Dispose();
            else
            {
                MessageBox.Show("Login or Password is incorrect");
            }
        }
    }
}

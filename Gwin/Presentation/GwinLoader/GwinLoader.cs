using SplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gwin.Presentation.GwinLoader
{
    public partial class GwinLoader : Form,ISplashForm
    {
        public GwinLoader()
        {
            InitializeComponent();
        }

        #region ISplashForm

        void ISplashForm.SetStatusInfo(string NewStatusInfo)
        {
            lbStatusInfo.Text = NewStatusInfo;
        }

        #endregion

        private void GwinLoader_Load(object sender, EventArgs e)
        {

        }

        private void GwinLoader_Click(object sender, EventArgs e)
        {
            
        }
    }
}
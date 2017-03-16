using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.MainForm
{
    public partial class FormLoader : Form
    {
        public FormLoader()
        {
            InitializeComponent();
            timer_loading.Enabled = true;
            timer_loading.Interval = 1000;
//timer_loading.Tick += Timer_loading_Tick;
           
        }

        private void Timer_loading_Tick(object sender, EventArgs e)
        {
            progressBarLoading.Value = progressBarLoading.Value + 1;
        }
    }
}

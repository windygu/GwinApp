using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App.Gwin.Fields
{
    public partial class ComboBoxField : BaseField
    {
        public ComboBoxField()
        {
            InitializeComponent();
        }

        public override object Value
        {
            get
            {
                return this.comboBox1.SelectedItem;
            }

            set
            {
                this.comboBox1.SelectedItem = value;
            }
        }

        public List<Object> DataSource
        {
            set
            {
                this.comboBox1.DataSource = value;
            }
        }

        public string DisplayMember
        {
            set
            {
                this.comboBox1.DisplayMember = value;
            }
        }
        public string ValueMember
        {
            set
            {
                this.comboBox1.ValueMember = value;
            }
        }


    }
}

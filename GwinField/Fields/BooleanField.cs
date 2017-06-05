using System;
using System.Drawing;

namespace GApp.GwinApp.Fields
{
    /// <summary>
    /// Default Field : Used to Show and Read Not Implmented Type supported Type by Gwin Application
    /// </summary>
    public partial class BooleanField : GApp.GwinApp.Fields.BaseField
    {
        /// <summary>
        /// Value of Object 
        /// </summary>
        public object ItemValue { set; get; }

        #region Properties
        /// <summary>
        ///  Value of Object
        /// </summary>
        public override object Value
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                if (value != null)
                {
                    this.ItemValue = value;
                    checkBox1.Checked = Convert.ToBoolean( value);
                }

            }
        }


        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public BooleanField() :base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialisation spécifique à zone de texte
        /// Exécuter aprés l'initialisation de du Size Field
        /// </summary>
        public override void ConfigSizeField()
        {
            base.ConfigSizeField();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            onValueChanged(this, e);
        }
    }
}

using App.Gwin.Application.Presentation.Messages;
using System;

namespace App.Gwin.Fields
{
    public partial class Int32Filed : App.Gwin.Fields.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur du champs
        /// </summary>
        public override object Value
        {
            get
            {
                if (textBoxFiled.Text == string.Empty) return 0;
                else
                {
                    int value = 0;
                    if (int.TryParse(textBoxFiled.Text, out value))
                    {
                        return value;
                    }
                    else
                    {
                        // [fr]
                        string Message = "Impossible de lire la valeur Entier: " + textBoxFiled.Text;
                        MessageToUser.AddMessage(MessageToUser.Category.Convert, Message);
                       
                         
                        return 0;
                    }
                }

            }
            set
            {
                textBoxFiled.Text = value.ToString();

            }
        }
        #endregion

        public Int32Filed() 
            : base()
        {
            InitializeComponent();
        }

        private void textBoxFiled_TextChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}

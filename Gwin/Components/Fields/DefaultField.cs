﻿using App.Gwin.Application.Presentation.Messages;
using System;
using System.Drawing;

namespace App.Gwin.Fields
{
    /// <summary>
    /// Default Field : Used to Show and Read Not Implmented Type supported Type by Gwin Application
    /// </summary>
    public partial class DefaultField : App.Gwin.Fields.BaseField
    {
        /// <summary>
        /// Value of Object 
        /// </summary>
        public object ItemValue { set; get;}

        #region Properties
        /// <summary>
        ///  Value of Object
        /// </summary>
        public override object Value
        {
            get
            {
                if (this.PropertyInfo?.PropertyType.IsPrimitive == true)
                {
                    try
                    {
                        return Convert.ChangeType(textBoxField.Text, this.PropertyInfo.PropertyType);
                    }
                    catch (FormatException e)
                    {
                        string msg = string.Format("Can not convert {0} to {1} ", textBoxField.Text, this.PropertyInfo.PropertyType.Name);
                        MessageToUser.AddMessage(MessageToUser.Category.Convert, msg);
                        return ItemValue;
                    }
                }
                   
                   
               return ItemValue;
            }
            set
            {
                if(value != null)
                {
                    this.ItemValue = value;
                    textBoxField.Text = this.ItemValue.ToString();
                }
                
            }
        }


        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public DefaultField() :base()
        {
            InitializeComponent();
        }

        
        private void textBoxField_TextChanged(object sender, EventArgs e)
        {
            onValueChanged(this, e);
        }
        /// <summary>
        /// Initialisation spécifique à zone de texte
        /// Exécuter aprés l'initialisation de du Size Field
        /// </summary>
        public override void ConfigSizeField()
        {
            base.ConfigSizeField();
        }

        

       
    }
}
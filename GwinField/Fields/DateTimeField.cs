using GApp.GwinApp.Fields.Controls;
using System;
using System.Drawing;

namespace GApp.Components.Fields
{
    public partial class DateTimeField : GApp.GwinApp.Fields.BaseField
    {
        #region Properties
        /// <summary>
        /// get the value of DateTimePicker
        /// </summary>
        public override object Value
        {
            get
            {
                return dateTimeControl.Value;
            }
            set
            {
                dateTimeControl.Value = Convert.ToDateTime(value);
            }
        }

        /// <summary>
        /// Values Used to Test Field
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTestValue()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Get the DateTimeControl included in this field
        /// </summary>
        public DateTimeControl DateTimeControl {
            get
            {
                return this.dateTimeControl;
            }
        }
        #endregion


        public DateTimeField() : base()
        {
            InitializeComponent();
        }

        public override void ConfigSizeField()
        {
            this.SizeControl = dateTimeControl.ChangeSizeControl(this.SizeControl);
            base.ConfigSizeField();
        }


        private void dateTimeControl_ValueChanged(object sender, EventArgs e)
        {
            onValueChanged(this, e);
        }
    }
}

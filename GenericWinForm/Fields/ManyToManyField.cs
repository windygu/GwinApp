using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinForm.Entities;
using App.WinForm.Fields.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.Fields
{
    public partial class ManyToManyField : App.WinFrom.Fields.BaseField
    {
        #region public Properties
        public override object Value
        {
            get
            {
                return listBoxChoices.SelectedItems.Cast<BaseEntity>().ToList<BaseEntity>();
            }

            set
            {
                List<BaseEntity> ls_values = value as List<BaseEntity>;
                // Update Filter selection
                if (this.SelectionFilterManager.isHasFilter && ls_values != null && ls_values.Count > 0)
                    this.SelectionFilterManager.Value = ls_values.First().Id;


                // Update Value
                foreach (var item in ls_values)
                {
                    listBoxChoices.DataSource = ls_values;
                    listBoxChoices.SelectedItems.Add(item);
                }

               
            }
        }
        #endregion

        #region Private Properties
        public IBaseBAO EntityBAO { get; set; }
        /// <summary>
        /// Type of The object that use this field
        /// </summary>
        protected Type TypeOfObject { set; get; }
        /// <summary>
        /// Meta information of the Field
        /// </summary>
        protected PropertyInfo PropertyInfo { set; get; }
        /// <summary>
        /// The configuration of the property
        /// </summary>
        protected ConfigProperty configProperty { get; set; }
        protected ConfigEntity ConfigEntity { get; set; }

        private SelectionFilterManager SelectionFilterManager { set; get; }
        #endregion


        public ManyToManyField() : base()
        {
            InitializeComponent();
        }

        public ManyToManyField(
            PropertyInfo propertyInfo,
            Orientation OrientationField,
            Size SizeLabel,
            Size SizeControl,
            ConfigEntity ConfigEntity,
            Control MainContainer, IBaseBAO Service)
            : base()
        {
            InitializeComponent();

            this.PropertyInfo = propertyInfo;
            this.orientationField = OrientationField;
            this.SizeLabel = SizeLabel;
            this.SizeControl = SizeControl;
            this.ConfigEntity = ConfigEntity;

            

            if (PropertyInfo != null)
                this.configProperty = new ConfigProperty(PropertyInfo, this.ConfigEntity);


            this.EntityBAO = Service;
            this.SelectionFilterManager = new SelectionFilterManager(this.EntityBAO,
                this.PropertyInfo,
                MainContainer,
                SizeLabel, SizeControl, OrientationField, ConfigEntity);
            if (this.SelectionFilterManager.isHasFilter)
            {
                this.SelectionFilterManager.ValueChanged += SelectionFilterManager_ValueChanged;
            }else
            {
                // Fill the listBox with the possible values
                Type TypeGenericList = this.PropertyInfo.PropertyType.GetGenericArguments()[0];
                IBaseBAO ServiceTypeGenericList = this.EntityBAO.CreateEntityInstanceByType(TypeGenericList);
                List<Object> ls_possible_value = ServiceTypeGenericList.GetAll();
                listBoxChoices.Items.AddRange(ls_possible_value.ToArray());

                this.SizeControl = new Size(this.SizeControl.Width, 20 * listBoxChoices.Items.Count);
                this.CallConfigSizeField();

            }
           

        }

        private void SelectionFilterManager_ValueChanged(object sender, EventArgs e)
        {
            BaseEntity ValueEntity = this.SelectionFilterManager.ValueEntity;

            Type Type_ValueEntity = ObjectContext.GetObjectType(ValueEntity.GetType());
            if (ValueEntity == null) return;

            Type TypeGenericList = this.PropertyInfo.PropertyType.GetGenericArguments()[0];
            IBaseBAO ServiceTypeGenericList = this.EntityBAO.CreateEntityInstanceByType(TypeGenericList);
            List<Object> ls_entity_in_filter = ServiceTypeGenericList.Recherche(
                 new Dictionary<string, object>() {
                    { Type_ValueEntity.Name, ValueEntity.Id }
                   });

            listBoxChoices.Items.AddRange(ls_entity_in_filter.ToArray());
            this.SizeControl = new Size(this.SizeControl.Width, 20 * listBoxChoices.Items.Count);
            this.CallConfigSizeField();


        }

        


    }
}

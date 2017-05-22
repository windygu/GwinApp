using App.Shared.AttributesManager;
using App.Gwin.Attributes;
using App.Gwin.EntityManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using App.Gwin.Application.BAL;
using System.Linq;
using App.Gwin.Entities;

namespace App.Gwin.Fields
{
    /// <summary>
    /// ManyToOne Field : Implemented as ComboBox and Filter
    /// Filter is implemeted as List of comboBoxes names as FilterCombo
    /// </summary>
    public partial class ManyToOneField : BaseField
    {

        #region Variables
        /// <summary>
        /// Le conteneur de l'interface, our que le Filed ajoute son filtre personnelle à l'interface 
        /// sous Forme des Field avant son Field
        /// </summary>
        public Control MainContainner { set; get; }
        /// <summary>
        /// Indique si le programme en état de changement de la vlaeurs pardéfaut du champs
        /// dans cette étape il aura l'éxécution seulement des événement d'initialisation
        /// et les événement de changement des valeurs ne seront pas exécuter
        /// </summary>
        public bool StopEventSelectedIndexChange { get; private set; }

        /// <summary>
        /// Indicate if the ManyToOneFiled instance is for Filter or for Field Property
        /// </summary>
        private bool isFilterItem { set; get; }

        private IGwinBaseBLO Service { set; get; }

        /// <summary>
        /// Type of The object that use this field
        /// </summary>
        protected Type TypeOfObject { set; get; }

        /// <summary>
        /// The configuration of the property
        /// </summary>
        public ConfigProperty ConfigProperty { get; set; }
        public ConfigEntity ConfigEntity { get; set; }
        #endregion


        #region Properties : ComboBox

        public string ValueMember
        {
            get { return this.comboBoxManyToOne.ValueMember; }
            set { this.comboBoxManyToOne.ValueMember = value; }
        }
        public string DisplayMember
        {
            get { return this.comboBoxManyToOne.DisplayMember; }
            set { this.comboBoxManyToOne.DisplayMember = value; }
        }

        public object DataSource
        {
            get { return this.comboBoxManyToOne.DataSource; }
            set { this.comboBoxManyToOne.DataSource = value; }
        }

        public int SelectedIndex
        {
            get { return this.comboBoxManyToOne.SelectedIndex; }
            set { this.comboBoxManyToOne.SelectedIndex = value; }
        }

        public Object SelectedValue
        {
            get { return this.comboBoxManyToOne.SelectedValue; }
            set { this.comboBoxManyToOne.SelectedValue = value; }
        }

        public object SelectedItem
        {
            get { return this.comboBoxManyToOne.SelectedItem; }
        }


        public string TextCombobox
        {
            get { return this.comboBoxManyToOne.Text; }
            set { this.comboBoxManyToOne.Text = value; }
        }
        #endregion

        /// <summary>
        /// Default value from Application Filter
        /// </summary>
        Int64 DefaultValue { set; get; }

        #region Set and Get Values
        /// <summary>
        /// Get ComboBox Selected Value
        /// </summary>
        public override Object Value
        {
            get
            {
                return comboBoxManyToOne.SelectedValue;
            }
            set
            {
                this.setAllValuesBySelectedValue((Int64)value);
            }
        }
        /// <summary>
        /// Set ComboFilter value
        /// </summary>
        /// <param name="value"></param>
        public void setAllValuesBySelectedValue(Int64 value)
        {
            this.CalculetePreviesValuesInFilter(Convert.ToInt64(value));
            this.ViewingDataInCombBoxAndFilter();
        }

        #endregion

        #region Variables CombFilter
        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ManyToOneField> ListeComboBox { set; get; }

        /// <summary>
        /// List of Types of Filter creterias
        /// </summary>
        Dictionary<string, Type> Criterias { set; get; }
        /// <summary>
        /// filter previes values of current value
        /// </summary>
        Dictionary<string, Int64> FilterPreviesValues { set; get; }

        #endregion

        #region Events
        private void comboBoxManyToOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            onValueChanged(this, e);
        }
        #endregion

        #region Constructeurs

        /// <summary>
        /// ManyTo One Constructor
        /// </summary>
        /// <param name="Service">BLO Instance</param>
        /// <param name="TypeObjet">Type of Object en Entity</param>
        /// <param name="propertyInfo">PropertyInfo instance</param>
        /// <param name="MainContainner">ManyToOne containner</param>
        /// <param name="OrientationFiled">Filed orientation</param>
        /// <param name="SizeLabel">Label size</param>
        /// <param name="SizeControl">Control size</param>
        /// <param name="DefaultValue">Default value from Application Filter</param>
        /// <param name="ConfigEntity">Config entity instance</param>
        public ManyToOneField(IGwinBaseBLO Service,
            Type TypeObjet,
            PropertyInfo propertyInfo,
            Control MainContainner,
            Orientation OrientationFiled,
            Size SizeLabel,
            Size SizeControl,
            Int64 DefaultValue, ConfigEntity ConfigEntity)
            : base()
        {
            InitializeComponent();

            // Test to support Designe Mode
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                // Params
                this.TypeOfObject = TypeObjet;
                this.PropertyInfo = propertyInfo;
                this.orientationField = OrientationFiled;
                this.SizeLabel = SizeLabel;
                this.SizeControl = SizeControl;
                this.ConfigEntity = ConfigEntity;
                this.MainContainner = MainContainner;
                this.Service = Service;

                // Type of Object 
                if (this.TypeOfObject == null && this.PropertyInfo != null)
                    this.TypeOfObject = this.PropertyInfo.PropertyType;

                // Create config property instance
                if (PropertyInfo != null)
                    this.ConfigProperty = new ConfigProperty(PropertyInfo, this.ConfigEntity);

                // Init Variables
                this.ListeComboBox = new Dictionary<string, ManyToOneField>();
                this.FilterPreviesValues = new Dictionary<string, long>();
                this.Criterias = new Dictionary<string, Type>();
                this.DefaultValue = DefaultValue;

                // isFilterItem
                // if Field don't have Property info : that mean the Field is FilterItem
                if (this.PropertyInfo == null)
                    this.isFilterItem = true;

                // Config Current ComboBox : ManyToOneField or ItemFilter by recursive call
                // Current comboBox  Display
                this.DisplayMember = this.ConfigEntity.GwinEntity.DisplayMember;
                this.ValueMember = "Id";
                this.Text_Label = this.ConfigEntity.GwinEntity.SingularName;
                this.ValueChanged += Value_SelectedIndexChanged;              

                // Create Filter if SelectionCriteria exist
                if (!this.isFilterItem && this.ConfigProperty.SelectionCriteria != null)
                {
                    // Create Filter 
                    CreateFilter();

                    // Calculete inital values of filter
                    CalculetePreviesValuesInFilter(DefaultValue);
                }

                // Insert current CombBox in ListComboBox and Criterias to be treat by ViewingDataInCombBoxAndFilter Algorithem 
                ListeComboBox.Add(this.TypeOfObject.Name, this);
                Criterias.Add(this.TypeOfObject.Name, this.TypeOfObject);

                // Show Data 
                if (!this.isFilterItem)
                    ViewingDataInCombBoxAndFilter();
            }
        }


        public ManyToOneField(IGwinBaseBLO Service,
            PropertyInfo propertyInfo,
            Control MainContainner,
            Orientation OrientationFiled,
            Size SizeLabel, Size SizeControl,
            Int64 DefaultFiltreValues,
            ConfigEntity ConfigEntity)
          : this(Service, null, propertyInfo, MainContainner, OrientationFiled, SizeLabel, SizeControl, DefaultFiltreValues, ConfigEntity)
        { }

        private ManyToOneField(IGwinBaseBLO Service, Type TypeObjet, ConfigEntity ConfigEntity)
           : this(Service, TypeObjet, null, null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20), 0, ConfigEntity)
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManyToOneField()
        {
            InitializeComponent();
            this.SizeLabel = new Size(50, 20);
            this.SizeControl = new Size(50, 20);
            this.orientationField = Orientation.Horizontal;
        }




        /// <summary>
        /// Show Data in CombBox and Filter
        /// </summary>
        protected void ViewingDataInCombBoxAndFilter()
        {
            // we have a list of ComboBox that contain Filter and ManyToOne ComBox
            // we shwo the first ComboBox in this list, other comboBox Data is Showen by ChangeValues event

            if (ListeComboBox.Values.Count() <= 0) return;


            ManyToOneField comboBox = ListeComboBox.Values.ElementAt(0);
            string key = ListeComboBox.Keys.ElementAt(0);
            IGwinBaseBLO service = this.Service
                .CreateServiceBLOInstanceByTypeEntity(Criterias[key]);

            // Load All Data for Update
            List<Object> ls = service.GetAll();

            // Add Black Value if requorid
            if (ConfigProperty?.EntryForm?.isDefaultIsEmpty == true)
                ls.Insert(0, new EmptyEntity());

            // Use default values if exisit
            if (this.FilterPreviesValues != null && this.FilterPreviesValues.Keys.Contains(key))
            {
               
                // Shwo All Data
                this.StopEventSelectedIndexChange = true;
                comboBox.DataSource = ls;
                this.StopEventSelectedIndexChange = false;

                // Select default Value
                comboBox.SelectedValue = this.FilterPreviesValues[key];
            }
            else
            {
                // Show Data 
                comboBox.DataSource = ls;
            }

        }



        //public void LoadData(Type TypeObjet,
        //    PropertyInfo propertyInfo,
        //    Control MainContainner,
        //    Orientation OrientationFiled,
        //    Size SizeLabel,
        //    Size SizeControl,
        //    Int64 DefaultValues, ConfigEntity ConfigEntity)
        //{


        //        this.TypeOfObject = TypeObjet;
        //        this.PropertyInfo = propertyInfo;
        //        this.ConfigEntity = ConfigEntity;


        //        if (PropertyInfo != null)
        //            this.ConfigProperty = new ConfigProperty(PropertyInfo, this.ConfigEntity);

        //        this.MainContainner = MainContainner;



        //        this.Service = Service;
        //        this.ListeComboBox = new Dictionary<string, ManyToOneField>();
        //        this.FilterDefaultsValues = new Dictionary<string, long>();
        //        this.Criterias = new Dictionary<string, Type>();
        //        this.DefaultValues = DefaultValues;


        //        InitAndLoadData();
        //        CalculeValeursInitiaux(DefaultValues);
        //        ViewingData();

        //}



        #endregion

    }
}

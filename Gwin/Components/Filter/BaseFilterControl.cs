using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using App.Gwin.Attributes;
using App.Gwin.Fields;
using App.Shared.AttributesManager;
using App.Gwin.Entities;
using System.Resources;
using App.Gwin.Shared.Resources;
using App.WinForm.Fields;

namespace App.Gwin.EntityManagement
{
    /// <summary>
    /// Filter control, it is used in 
    /// Management Interface
    /// </summary>
    public partial class BaseFilterControl : UserControl, IBaseFilterControl
    {

        #region Public Properties

        #endregion

        #region Private Properties
        /// <summary>
        /// Get or Set the Filter Values
        /// The filter value can be of several types: String, Int, DateTime
        /// Return Dictionary String, Object
        /// String : the name of entity property
        /// Object : the value of field
        /// </summary>
        protected Dictionary<string, object> FilterValues { set; get; }

        /// <summary>
        /// BAO Object   
        /// </summary>
        protected IBaseBLO BAO { set; get; }



        /// <summary>
        /// The main filter interface container 
        /// </summary>
        protected Control FilterContainer { set; get; }

        protected ConfigEntity ConfigEntity { get;  set; }

        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            if (RefreshEvent != null)
                RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeurs
        public BaseFilterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BaseFilterControl Constructor
        /// </summary>
        /// <param name="BAO">Entity Business Object</param>
        /// <param name="ValeursFiltre"></param>
        public BaseFilterControl(IBaseBLO BAO, Dictionary<string, object> ValeursFiltre)
        {
            InitializeComponent();
            this.FilterContainer = this.flowLayoutPanel1;
            this.BAO = BAO;
            this.FilterValues = ValeursFiltre;
            this.ConfigEntity =   ConfigEntity.CreateConfigEntity(this.BAO.TypeEntity);
            initFiltre();
        }

        public BaseFilterControl(IBaseBLO Service) : this(Service, null)
        {
        }

        #endregion

        #region InitializeFilter

        /// <summary>
        /// Recherche des propriété qui doivent être utiliser dans le filtre
        /// </summary>
        /// <returns></returns>
        protected List<PropertyInfo> PropertyListFilter()
        {
            // [Bug]
            // Ajoutez la condition filtre 
            var requete = from i in BAO.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(FilterAttribute)) != null 
                          orderby ((FilterAttribute)i.GetCustomAttribute(typeof(FilterAttribute))).Ordre
                          select i;
            return requete.ToList<PropertyInfo>();
        }

        /// <summary>
        /// Initialisation de filtre 
        /// </summary>
        protected void initFiltre()
        {
            // Postion et Taille par défaut
            int width_label = 100;
            int height_label = 25;
            int width_control = 100;
            int height_control = 20;
            int TabIndex = 0;


            var propertyListFilter = from i in BAO.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(FilterAttribute)) != null
                          orderby ((FilterAttribute)i.GetCustomAttribute(typeof(FilterAttribute))).Ordre
                          select i;


            // Insertion des critère de recherche par Type
            foreach (PropertyInfo propertyInfo in propertyListFilter)
            {
                ConfigProperty attributesOfProperty = new ConfigProperty(propertyInfo, this.ConfigEntity);
 
                // Utiliser le Largeur de la configuration s'il existe
                int item_width_control = width_control;
                if(attributesOfProperty.Filter?.WidthControl != 0)
                    item_width_control = attributesOfProperty.Filter.WidthControl;

                if (propertyInfo.PropertyType.Name == "String")
                {
                    StringField stringFiled = new StringField();
                    stringFiled.StopAutoSizeConfig();
                    stringFiled.Name = propertyInfo.Name;
                    stringFiled.SizeLabel = new Size(width_label, height_label);
                    stringFiled.SizeControl = new Size(item_width_control, height_control);
                    stringFiled.OrientationField = Orientation.Horizontal;
                    stringFiled.TabIndex = TabIndex++;
                    stringFiled.Text_Label = attributesOfProperty.DisplayProperty.Titre;
                    stringFiled.FieldChanged += Filtre_TextBox_SelectedValueChanged;
                    stringFiled.ConfigSizeField();
                    FilterContainer.Controls.Add(stringFiled);
                }
                if (propertyInfo.PropertyType.Name == "Int32")
                {
                    Int32Filed int32Filed = new Int32Filed();
                    int32Filed.StopAutoSizeConfig();
                    int32Filed.Name = propertyInfo.Name;
                    int32Filed.SizeLabel = new Size(width_label, height_label);
                    int32Filed.SizeControl = new Size(item_width_control, height_control);
                    int32Filed.OrientationField = Orientation.Horizontal;
                    int32Filed.TabIndex = TabIndex++;
                    int32Filed.Text_Label = attributesOfProperty.DisplayProperty.Titre;
                    int32Filed.FieldChanged += Filtre_TextBox_SelectedValueChanged;
                    int32Filed.ConfigSizeField();
                    FilterContainer.Controls.Add(int32Filed);
                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    DateTimeField dateTimeField = new DateTimeField();
                    dateTimeField.StopAutoSizeConfig();
                    dateTimeField.Name = propertyInfo.Name;
                    dateTimeField.SizeLabel = new Size(width_label, height_label);
                    dateTimeField.SizeControl = new Size(item_width_control, height_control);
                    dateTimeField.OrientationField = Orientation.Horizontal;
                    
                    dateTimeField.TabIndex = TabIndex++;
                    dateTimeField.Text_Label = attributesOfProperty.DisplayProperty.Titre;

                    
                    dateTimeField.FieldChanged += Filtre_TextBox_SelectedValueChanged;
                    dateTimeField.ConfigSizeField();
                    FilterContainer.Controls.Add(dateTimeField);
                }

                //
                // Relation ManyToOne
                //
                if (attributesOfProperty.Relationship?.Relation != RelationshipAttribute.Relations.Empty &&
                 attributesOfProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
                {
                    // La valeurs pardéfaut
                    Int64 default_value = 0;
                    if(FilterValues != null && FilterValues.Keys.Contains(propertyInfo.PropertyType.Name))
                        default_value = (Int64)FilterValues[propertyInfo.PropertyType.Name];

                    ManyToOneField manyToOneField = new ManyToOneField(this.BAO, propertyInfo,
                        this.FilterContainer,
                        Orientation.Horizontal,
                         new Size(width_label, height_label),
                         new Size(item_width_control, height_control),
                         default_value, ConfigEntity
                        );
                    manyToOneField.Name = propertyInfo.Name;
                    manyToOneField.TabIndex = TabIndex++;
                    manyToOneField.Text_Label =  attributesOfProperty.DisplayProperty.Titre;
                    manyToOneField.FieldChanged += Filtre_ComboBox_SelectedValueChanged;
                    FilterContainer.Controls.Add(manyToOneField);


                    //
                    // Remplissage de ComboBox
                    //
                    //Type ServicesEntityEnRelationType = typeof(BaseRepository<>).MakeGenericType(propertyInfo.PropertyType);
                    //IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityEnRelationType);
                    //List<object> ls = ServicesEntity.GetAllDetached();
                    //manyToOneField.ValueMember = "Id";
                    //manyToOneField.DisplayMember = AffichagePropriete.DisplayMember;
                    //manyToOneField.DataSource = ls;
                    //if (AffichagePropriete.isValeurFiltreVide) manyToOneField.SelectedIndex = -1;

                    //// Affectation de valeur initial
                    //if (this.ValeursFiltre != null && this.ValeursFiltre.ContainsKey(propertyInfo.Name))
                    //{
                    //    manyToOneField.CreateControl();
                    //    manyToOneField.Value = Convert.ToInt64(this.ValeursFiltre[propertyInfo.Name]);
                    //}



                }




                //if (MainContainer.Controls.Count > 0)
                //{
                //    int max_h = this.MainContainer.Controls.Cast<Control>().Max(c => c.Size.Height);
                //    this.MainContainer.Size = new Size(this.MainContainer.Size.Width, max_h);
                //}

            } // End For
        }

        /// <summary>
        /// Evénement SelectValueChange de ComboBoxs des Propriétés avec Relation :MnayToOne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtre_TextBox_SelectedValueChanged(object sender, EventArgs e)
        {
            onRefreshEvent(sender, e);
        }
        private void Filtre_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var item in this.groupBoxFiltrage.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            onRefreshEvent(sender, e);
        }


        #endregion

        #region Read & Write
        /// <summary>
        /// Obtient les valeurs du filtre
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> CritereRechercheFiltre()
        {
            // Application de filtre
            Dictionary<string, object> RechercheInfos = new Dictionary<string, object>();


            var PropertyListFilter = from i in BAO.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(FilterAttribute)) != null
                          orderby ((FilterAttribute)i.GetCustomAttribute(typeof(FilterAttribute))).Ordre
                          select i;
            

            foreach (PropertyInfo propertyInfo in PropertyListFilter)
            {
               
                switch (propertyInfo.PropertyType.Name)
                {
                    case "String":
                        {
                            StringField stringFiled = (StringField)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if (stringFiled.Value != String.Empty)
                                RechercheInfos[propertyInfo.Name] = stringFiled.Value;
                        }
                        break;
                    case "Int32":
                        {
                            Int32Filed int32Filed = (Int32Filed)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if ((int) int32Filed.Value != 0)
                                RechercheInfos[propertyInfo.Name] = int32Filed.Value;
                        }
                        break;
                    case "DateTime":
                        {
                            DateTimeField dateTimeField = (DateTimeField)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if ((DateTime)dateTimeField.Value != DateTime.MinValue)
                                RechercheInfos[propertyInfo.Name] = dateTimeField.Value;
                        }
                        break;
                    default: // Dans le cas d'un objet de type BaseEntity
                        {
                            ConfigProperty ConfigProperty = new ConfigProperty(propertyInfo, this.ConfigEntity);

                            if (ConfigProperty.Relationship.Relation == RelationshipAttribute.Relations.ManyToOne)
                            {
                                // [bug] groupBoxFiltrage doit être MainContainner
                                ManyToOneField ComboBoxEntity = (ManyToOneField)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                                BaseEntity obj = (BaseEntity)ComboBoxEntity.SelectedItem;
                                if (obj != null && Convert.ToInt32(obj.Id) != 0)
                                    RechercheInfos[propertyInfo.Name] = obj.Id;
                            }
                        }
                        break;
                }



            }

            return RechercheInfos;
        }

        #endregion

        private void groupBoxFiltrage_Enter(object sender, EventArgs e)
        {

        }
    }
}

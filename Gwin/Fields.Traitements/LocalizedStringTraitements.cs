using App.Gwin.Entities.MultiLanguage;
using App.Gwin.Exceptions.Gwin;
using App.Gwin.Fields;
using App.Gwin.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Shared.AttributesManager;

namespace App.Gwin.FieldsTraitements
{
    public class LocalizedStringFieldTraitement : FieldTraitement, IFieldTraitements
    {
        /// <summary>
        /// CreateField in EntryForm
        /// 
        /// </summary>
        /// <param name="param">
        /// param.PropertyInfo
        /// param.Location 
        /// param.OrientationField 
        /// param.SizeLabel 
        /// param.SizeControl 
        /// param.ConfigProperty 
        /// param.TabIndex 
        /// param.Service 
        /// param.ConfigEntity
        /// param.TabControlForm
        /// param.Entity
        /// param.ConteneurFormulaire
        /// </param>
        /// <returns>the created field</returns>
        public BaseField CreateField_In_EntryForm(CreateFieldParams param)
        {
            StringField stringField = new StringField();
            stringField.StopAutoSizeConfig();
            stringField.Name = param.PropertyInfo.Name;
            stringField.Location = param.Location;
            stringField.OrientationField = param.OrientationField;
            stringField.SizeLabel = param.SizeLabel;
            stringField.SizeControl = param.SizeControl;
            
            stringField.TabIndex = param.TabIndex;
            stringField.Text_Label = param.ConfigProperty.DisplayProperty.Titre;
            stringField.ConfigSizeField();

            // Insertion à l'interface
            param.ConteneurFormulaire.Controls.Add(stringField);
            return stringField;
        }

      

        public void WriteEntity_To_EntryForm(WriteEntity_To_EntryForm_Param param)
        {
            LocalizedString valeur = (LocalizedString)param.Entity.GetType().GetProperty(param.ConfigProperty.PropertyInfo.Name).GetValue(param.Entity);

            // Use Filter Value
            if (param.CritereRechercheFiltre != null && param.CritereRechercheFiltre.ContainsKey(param.ConfigProperty.PropertyInfo.Name))
                valeur.Current = param.CritereRechercheFiltre[param.ConfigProperty.PropertyInfo.Name].ToString();

            // Find baseField control in ConteneurFormulaire
            // And Set Value
            Control[] recherche = param.FromContainer.Controls.Find(param.ConfigProperty.PropertyInfo.Name, true);
            if (recherche.Count() > 0)
            {
                BaseField baseField = (BaseField)recherche.First();
                if (baseField == null) throw new GwinException("The field " + param.ConfigProperty.PropertyInfo.Name + "not exit in EntryForm");
               
                if (valeur != null)
                    baseField.Value = valeur.Current;
            }

        }

        #region Filter 
        /// <summary>
        /// Create Field in Filter
        /// </summary>
        /// <param name="param">Parameters</param>
        /// <returns>The created field</returns>
        public BaseField CreateField_In_Filter(CreateField_In_Filter_Params param)
        {
            StringField stringFiled = new StringField();
            stringFiled.StopAutoSizeConfig();
            stringFiled.Name = param.ConfigProperty.PropertyInfo.Name;
            stringFiled.SizeLabel = param.SizeLabel;
            stringFiled.SizeControl = param.SizeControl;
            stringFiled.OrientationField = Orientation.Horizontal;
            stringFiled.TabIndex = param.TabIndex;
            stringFiled.Text_Label = param.ConfigProperty.DisplayProperty.Titre;

            stringFiled.ConfigSizeField();
            param.FilterContainer.Controls.Add(stringFiled);

            return stringFiled;
        }

        /// <summary>
        /// Get Field Value from Filter
        /// </summary>
        /// <param name="FilterContainer">Filter container</param>
        /// <param name="ConfigProperty">Config property instance</param>
        /// <returns>Value of Field in Filter</returns>
        public object GetFieldValue_From_Filter(Control FilterContainer, ConfigProperty ConfigProperty)
        {
            StringField stringFiled = (StringField)FilterContainer.Controls.Find(ConfigProperty.PropertyInfo.Name, true).First();
            if (stringFiled.Value.ToString() != "")
                return stringFiled.Value;
            else
                return null;
        }
        #endregion
    }
}

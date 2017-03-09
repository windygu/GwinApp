using App.Gwin.Exceptions.Gwin;
using App.Gwin.Fields;
using App.Gwin.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements.Params;
using App.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.FieldsTraitements
{
    public class Int32FieldTraitement : FieldTraitement, IFieldTraitements
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
            Int32Filed int32Filed = new Int32Filed();
            int32Filed.StopAutoSizeConfig();
            int32Filed.Name = param.PropertyInfo.Name;
            int32Filed.Location = param.Location;
            int32Filed.OrientationField = param.OrientationField;
            int32Filed.SizeLabel = param.SizeLabel;
            int32Filed.SizeControl = param.SizeControl;
            
            int32Filed.TabIndex = param.TabIndex;
            int32Filed.Text_Label = param.ConfigProperty.DisplayProperty.Titre;
            int32Filed.ConfigSizeField();

            // Insertion à l'interface
            param.ConteneurFormulaire.Controls.Add(int32Filed);
            return int32Filed;
        }

        public void WriteEntity_To_EntryForm(WriteEntity_To_EntryForm_Param param)
        {
            int valeur = (int)param.Entity.GetType().GetProperty(param.ConfigProperty.PropertyInfo.Name).GetValue(param.Entity);

            // Use Filter Value
            if (param.CritereRechercheFiltre != null && param.CritereRechercheFiltre.ContainsKey(param.ConfigProperty.PropertyInfo.Name))
                valeur = Convert.ToInt32(param.CritereRechercheFiltre[param.ConfigProperty.PropertyInfo.Name]); 

            // Find baseField control in ConteneurFormulaire
            // And Set Value
            Control[] recherche = param.FromContainer.Controls.Find(param.ConfigProperty.PropertyInfo.Name, true);
            if (recherche.Count() > 0)
            {
                BaseField baseField = (BaseField)recherche.First();
                if (baseField == null) throw new GwinException("The field " + param.ConfigProperty.PropertyInfo.Name + "not exit in EntryForm");
                baseField.Value = valeur;
            }

        }

        public BaseField CreateField_In_Filter(CreateField_In_Filter_Params param)
        {
            Int32Filed int32Filed = new Int32Filed();
            int32Filed.StopAutoSizeConfig();
            int32Filed.Name = param.ConfigProperty.PropertyInfo.Name;
            int32Filed.SizeLabel = param.SizeLabel;
            int32Filed.SizeControl = param.SizeControl;
            int32Filed.OrientationField = Orientation.Horizontal;
            int32Filed.TabIndex = param.TabIndex;
            int32Filed.Text_Label = param.ConfigProperty.DisplayProperty.Titre;

            int32Filed.ConfigSizeField();
            param.FilterContainer.Controls.Add(int32Filed);

            return int32Filed;
        }

        public object GetFieldValue_From_Filter(Control FilterContainer, ConfigProperty ConfigProperty)
        {
            Int32Filed int32Filed = (Int32Filed)FilterContainer.Controls.Find(ConfigProperty.PropertyInfo.Name, true).First();
            if ((int)int32Filed.Value != 0)
                return int32Filed.Value;
            else
                return null;
        }

      
    }
}

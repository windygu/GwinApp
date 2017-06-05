using GApp.GwinApp.Fields;
using GApp.GwinApp.Components.Manager.Fields.Traitements.Params;
using GApp.Shared.AttributesManager;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace GApp.GwinApp.FieldsTraitements
{
    public interface IFieldTraitements
    {

        BaseField CreateField_In_EntryForm(CreateFieldParams param);
        void ShowEntity_To_EntryForm(WriteEntity_To_EntryForm_Param param);
        object ConvertValue(BaseFieldTraitementParam param);

        BaseField CreateField_In_Filter(CreateField_In_Filter_Params param);
        object GetFieldValue_From_Filter(Control FilterContainer, ConfigProperty ConfigProperty);

        void ConfigFieldColumn_In_EntityDataGrid(CreateFieldColumns_In_EntityDataGrid param);

        object GetTestValue(PropertyInfo propertyInfo);

       
    }
}
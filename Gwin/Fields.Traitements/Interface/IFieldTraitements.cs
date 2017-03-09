using App.Gwin.Fields;
using App.Gwin.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements.Params;
using App.Shared.AttributesManager;
using System;
using System.Windows.Forms;

namespace App.Gwin.FieldsTraitements
{
    public interface IFieldTraitements
    {

        BaseField CreateField_In_EntryForm(CreateFieldParams param);
        void WriteEntity_To_EntryForm(WriteEntity_To_EntryForm_Param param);
        BaseField CreateField_In_Filter(CreateField_In_Filter_Params param);
        object GetFieldValue_From_Filter(Control FilterContainer, ConfigProperty ConfigProperty);
    }
}
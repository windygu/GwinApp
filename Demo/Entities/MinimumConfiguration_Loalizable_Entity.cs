using App.Gwin.Attributes;
using App.Gwin.Entities;
namespace GenericWinForm.Demo.Entities
{

    [DisplayEntity(Localizable =true,DisplayMember = "Name")]
    [Menu]
    public class MinimumConfiguration_Loalizable_Entity : BaseEntity
    {
        [DisplayProperty]
        [EntryForm]
        [Filter]
        [DataGrid]
        public string StingField { set; get; }


        [EntryForm(MultiLine =true)]
        [Filter]
        [DataGrid]
        public string MultiLine_StingField { set; get; }

   
        [EntryForm]
        [Filter]
        [DataGrid]
        public int IntField { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public System.DateTime DateTimeField { set; get; }
    }
}

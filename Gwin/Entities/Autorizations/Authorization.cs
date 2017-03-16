using App.Gwin.Attributes;
using App.Gwin.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Autorizations
{
    [DisplayEntity(DisplayMember =nameof(Authorization.EntityBLOName),Localizable =true)]
    [Menu(Group = "Admin")]
    public class Authorization : BaseEntity
    {
       

        /// <summary>
        /// Entity Name : NameSpace.EntityName
        /// </summary>
        [Filter(WidthControl = 400,isValeurFiltreVide = true)]
        [EntryForm(WidthControl = 400)]
        [DataGrid(WidthColonne = 400)]
        [DataSource(TypeObject = typeof(ModelConfiguration),
            MethodeName = nameof(ModelConfiguration.GetAll_Entities_Type),
            DisplayName ="Name")]
        public String EntityBLOName { set; get; }

        /// <summary>
        /// Action to Autoritze, Enummeration
        /// </summary>
        [EntryForm]
        [DataGrid]
        public List<String> MethodesNames { set; get; }
    }
}

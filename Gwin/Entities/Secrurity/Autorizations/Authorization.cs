using App.Gwin.Attributes;
using App.Gwin.DataModel.ModelInfo;
using App.Gwin.GwinApplication.Security.Attributes;
using App.Gwin.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Secrurity.Autorizations

{
    [GwinEntity(DisplayMember = nameof(Authorization.Name), Localizable = true)]
    [Menu(Group = "Admin")]
    public class Authorization : BaseEntity
    {
        [Filter]
        [EntryForm]
        [DataGrid]
        public String Name { set; get; }

        [EntryForm]
        public String Description { set; get; }

        /// <summary>
        /// Entity Name : NameSpace.EntityName
        /// </summary>
        [Filter(WidthControl = 400, isValeurFiltreVide = true)]
        [EntryForm(WidthControl = 400)]
        [DataGrid(WidthColonne = 400)]
        [DataSource(TypeObject = typeof(GwinBusinessEntitiesManager),
            MethodeName = nameof(GwinBusinessEntitiesManager.GetAll),
            Param1 =typeof(AuthorizeAttribute),
            DisplayName ="Name")]
        public String BusinessEntity { set; get; }

        /// <summary>
        /// Mathods Authorized Names
        /// </summary>
        [EntryForm]
        [DataGrid]
        public virtual List<String> ActionsNames { set; get; }


        /// <summary>
        /// Maaping of ActionsNames
        /// </summary>
        public string ActionsNamesAsString
        {
            get { return string.Join(",", ActionsNames); }
            set { ActionsNames = value.Split(',').ToList(); }
        }


        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<Role> Roles { set; get; }
    }
}

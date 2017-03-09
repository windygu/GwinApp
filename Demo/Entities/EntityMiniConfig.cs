using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.Autorizations;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.ModelData;
using System.Collections.Generic;

namespace GenericWinForm.Demo.Entities
{

    [DisplayEntity(Localizable =true,DisplayMember = "Name")]
    [Menu]
    public class EntityMiniConfig : BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public string StringField { set; get; }


        [EntryForm(MultiLine =true)]
        [Filter]
        [DataGrid]
        public string MultiLine_StingField { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString LocalizedString { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public System.DateTime DateTimeField { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public int IntField { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        [DataSource(TypeObject = typeof(ModelConfiguration),
            MethodeName = nameof(ModelConfiguration.GetAll_Entities_Type),
            DisplayName = "Name")]
        public string StringWithDataSource { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public UserActionInGwin Enumeration { set; get; }


        [EntryForm]
        [Filter]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public Entity_OneToMany Entity_OneToMany { set; get; }


        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public virtual List<Entity_ManyToMany> ManyToMany_Creation { set; get; }

        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public virtual List<Entity_ManyToMany> ManyToMany_Selection { set; get; }
    }
}

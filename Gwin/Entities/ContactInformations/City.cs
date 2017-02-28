using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.ContactInformations
{
    [DisplayEntity(Localizable =true, isMaleName = false,DisplayMember = "Name")]
    [Menu(Group = "The Configuration")]
    [SelectionCriteria(typeof(Country))]
    public class City : BaseEntity
    {
        [DisplayProperty(isInGlossary = true)]
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Name { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(MultiLine = true)]
        public string Description { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm]
        [Filter]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public virtual Country Country { set; get; }
}
}

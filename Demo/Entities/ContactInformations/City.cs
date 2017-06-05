using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Entities.Application;
using GApp.GwinApp.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWinForm.Demo.Entities.ContactInformations
{
    [GwinEntity(Localizable =true, isMaleName = false,DisplayMember = "Name")]
    [Menu(Group = nameof(MenuItemApplication.ParentsMenuItem.Configuration),Order = 100)]
    [SelectionCriteria(typeof(Country))]
    public class City : BaseEntity
    {
        [DisplayProperty(isInGlossary = true)]
        [EntryForm(isRequired =true)]
        [Filter]
        [DataGrid]
        public LocalizedString Name { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(MultiLine = true)]
        public LocalizedString Description { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm]
        [Filter(isDefaultIsEmpty =true)]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public virtual Country Country { set; get; }
}
}

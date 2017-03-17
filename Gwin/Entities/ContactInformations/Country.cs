using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.ContactInformations
{
    [GwinEntity(Localizable =true,isMaleName =true,DisplayMember = "Name")]
    [Menu(Group = "The Configuration")]
    public class Country : BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString Name { set; get; }

        [EntryForm(MultiLine =true)]
        [DataGrid]
        public LocalizedString Description { set; get; }

        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        public virtual List<City> Citys { set; get; }
    }
}

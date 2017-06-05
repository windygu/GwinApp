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
    [GwinEntity(Localizable =true,isMaleName =true,DisplayMember = "Name")]
    [Menu(Group = nameof(MenuItemApplication.ParentsMenuItem.Configuration),Order = 101)]
    [ManagementForm(Localizable = true,Width = 550,Height = 450)]
    public class Country : BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public  LocalizedString Name { set; get; }

        [EntryForm(MultiLine =true)]
        [DataGrid]
        public LocalizedString Description { set; get; }

     
        [Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        public virtual List<City> Citys { set; get; }
    }
}

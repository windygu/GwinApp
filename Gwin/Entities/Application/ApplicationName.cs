using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Entities.MultiLanguage;
using GApp.GwinApp.GwinApplication.Security.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Entities.Application
{
    [GwinEntity(Localizable =true,isMaleName =false,DisplayMember ="Name",PluralName ="Applications",SingularName = "Application")]
    [Menu(Group =nameof(MenuItemApplication.ParentsMenuItem.Root))]
    [Authorize]
    public class ApplicationName : BaseEntity
    {
       
        public ApplicationName()
        {
            this.Name = new LocalizedString();
            this.Description = new LocalizedString();
        }
        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString Name { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString Description { set; get; }
    }
}

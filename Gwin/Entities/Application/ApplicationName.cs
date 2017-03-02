using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Application
{
    [DisplayEntity(Localizable =true,isMaleName =false,DisplayMember ="Name",PluralName ="Applications",SingularName = "Application")]
    [Menu(Group ="Root")]
    public class ApplicationName : BaseEntity
    {


        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString Name { set; get; }

        [EntryForm]
        [Filter]
        [DataGrid]
        public string Description { set; get; }

        
    }
}

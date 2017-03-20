using App.Gwin.Attributes;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.Entities.Secrurity.Autorizations;
using App.Gwin.GwinApplication.Security.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Application
{
    [GwinEntity(Localizable =true, DisplayMember = nameof(Code),isMaleName =true)]
    [Menu(Group ="Admin")]
    [Authorize]
    public class MenuItemApplication : BaseEntity
    {
        public MenuItemApplication()
        {
            this.Title = new LocalizedString();
            this.Description = new LocalizedString();
        }
        // Name & Description
        [DisplayProperty(isInGlossary =true)]
        [EntryForm(Ordre = 2)]
        [Filter]
        [DataGrid]
        [StringLength(65)]
        [Index("IX_Code",1, IsUnique = true)]
        public string Code { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 3, MultiLine = true)]
        [DataGrid]
        public LocalizedString Description { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2)]
        [Filter]
        [DataGrid]
        public LocalizedString Title { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2)]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection,EditMode= RelationshipAttribute.EditingModes.Selection_With_Check_Box)]
        public virtual List<Role> Roles { set; get; }
    }
}

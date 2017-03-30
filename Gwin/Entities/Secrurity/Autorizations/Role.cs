using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Secrurity.Autorizations
{
    /// <summary>
    /// This Eity is Used by Test Project to Teste : 
    /// BaseBAO
    /// </summary>
    [GwinEntity(DisplayMember = "Name",Localizable =true)]
    [Menu(Group = "Root")]
    public class Role : BaseEntity
    {

        enum Roles
        {
            root,
            admin

        }


        public Role()
        {
            this.Name = new LocalizedString();
            this.Description = new LocalizedString();
        }

        [EntryForm(Ordre = 1)]
        [Filter]
        [DataGrid]
        [Required]
        public LocalizedString Name { set; get; }

        [EntryForm(Ordre = 2,MultiLine = true)]
        [Filter]
        [DataGrid]
        public LocalizedString Description { set; get; }

        /// <summary>
        /// indicate that the role is hidden
        /// </summary>
        public bool Hidden { set; get; }

        [DataGrid]
        [EntryForm]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public virtual List<Authorization> Authorizations { set; get; }

        public  List<MenuItemApplication> MenuItemApplications { set; get; }

    }
}

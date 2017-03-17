using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
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
    [Menu(Group = "The Configuration")]
    public class Role : BaseEntity
    {
        [DisplayProperty(Titre ="Name",isInGlossary =true)]
        [EntryForm(Ordre = 1)]
        [Filter]
        [DataGrid]
        [Required]
        public string Name { set; get; }

        [DisplayProperty(Titre = "Description",isInGlossary =true)]
        [EntryForm(Ordre = 2,MultiLine = true)]
        [Filter]
        [DataGrid]
        public string Description { set; get; }

        /// <summary>
        /// indicate that the role is hidden
        /// </summary>
        public bool Hidden { set; get; }

        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public virtual List<Authorization> Authorizations { set; get; }

        public  List<MenuItemApplication> MenuItemApplications { set; get; }

    }
}

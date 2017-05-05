using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.GwinApplication.Security.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWinForm.Demo.Entities
{
    /// <summary>
    /// Entity Exemple to be used in ManyToOne RelationShip
    /// </summary>
    [GwinEntity(DisplayMember = "Title")]
    [Authorize]
    [Menu]
    public class Project:BaseEntity
    {

        public Project()
        {
            this.Description = new LocalizedString();
        }

        [EntryForm]
        [Filter]
        [DataGrid]
        [BusinesRole]
        public string Title { set; get; }


        [EntryForm(MultiLine = true,WidthControl =300)]
        [Filter]
        [DataGrid]
        public LocalizedString Description { set; get; }


        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public List<TaskProject> TaskProjects { set; get; }


    }
}

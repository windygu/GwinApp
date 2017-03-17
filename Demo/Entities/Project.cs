using App.Gwin.Attributes;
using App.Gwin.Entities;
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
    public class Project:BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Title { set; get; }
    }
}

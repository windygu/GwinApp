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
    /// Entity Exemple to be used in ManyToMany relationship 
    /// </summary>
    [DisplayEntity(DisplayMember ="Title")]
    public class Entity_ManyToMany : BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Title { set; get; }

        public List<EntityMiniConfig> EntityMiniConfig_selection { set; get; }
        public List<EntityMiniConfig> EntityMiniConfig_creation { set; get; }
    }
}

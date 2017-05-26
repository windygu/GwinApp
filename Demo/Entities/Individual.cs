using App.Gwin.Attributes;
using App.Gwin.GwinApplication.Security.Attributes;
using GenericWinForm.Demo.Entities.Persons;
using GenericWinForm.Demo.Entities.ProjectManager;
using System.Collections.Generic;

namespace GenericWinForm.Demo.Entities
{
    /// <summary>
    /// Entity Exemple to be used in ManyToMany relationship 
    /// </summary>
    [GwinEntity(DisplayMember ="Title")]
    [Authorize]
    public class Individual : Person
    {
        public List<TaskProject> Histasks { set; get; }
        public List<TaskProject> ResponsibilityFortasks { set; get; }
    }
}

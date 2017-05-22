using App.Gwin.Attributes;
using App.Gwin.Entities;
using GenericWinForm.Demo.Entities.TrainingManagement;
using GenericWinForm.Demo.Presentation.TraineeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GenericWinForm.Demo.Entities.TraineeManagement
{

    [GwinEntity(Localizable =true,DisplayMember = "Name")]
    [SelectionCriteria(typeof(Specialty))]
    [Menu(Group= "Trainee")]
    [PresentationLogic(TypePLO = typeof(GroupPLO))]
    public class Group : BaseEntity
    {
        
        [DisplayProperty(isInGlossary =true)]
        [EntryForm(Ordre = 2)]
        [Filter]
        [DataGrid(WidthColonne = 150)]
        public string Name { set; get; }


        [DisplayProperty(DisplayMember ="Code")]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [EntryForm(Ordre = 3)]
        [Filter(isValeurFiltreVide =true)]
        [DataGrid(WidthColonne = 100)]
        public virtual Specialty Specialty { set; get; }

    }
}

using App.Gwin.Attributes;
using App.Gwin.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GenericWinForm.Demo.Entities.TraineeManagement
{
    [GwinEntity(Localizable = true, isMaleName = true, DisplayMember = "Name")]
    [Menu(Group = "Trainee")]
    public class Trainee : Person
    {
         
        public int State { set; get; }

        // Affectation
        [DisplayProperty(DisplayMember = "Nom")]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [EntryForm(Ordre = 3,GroupeBox = "Assignments")]
        [Filter]
        [DataGrid(WidthColonne = 100)]
        public virtual Group Group { set; get; }


        //public virtual List<MiniGroupe> MiniGroupes { set; get; }

       
        //// Gestion des tâches
        //public virtual List<Tache> Taches { set; get; }

    }
}


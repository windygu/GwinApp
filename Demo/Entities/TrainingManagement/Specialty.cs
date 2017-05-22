using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GenericWinForm.Demo.Entities.TrainingManagement
{

   [GwinEntity(Localizable =true,DisplayMember ="Code")]
   [Menu(Group = "InstitutionManagement")]
    public class Specialty : BaseEntity 
   {

        public Specialty()
        {
            this.Title = new LocalizedString();
            Description = new LocalizedString();
        }

        [EntryForm(Ordre = 1,WidthControl =300)]
        [Filter]
        [DataGrid(WidthColonne = 150)]
        public LocalizedString Title { set; get; }

       
        [EntryForm(Ordre = 2,WidthControl =100)]
        [Filter]
        [DataGrid]
        public  String Code { set; get; }

        [EntryForm(Ordre = 3,MultiLine =true,NumberLine =10,WidthControl =300)]
        [DataGrid(WidthColonne =200)]
        public LocalizedString Description { set; get; }

         
        public List<TraineeManagement.Group> Groups { set; get; }
        // public  List<Module> Modules { set; get; }
    }
}
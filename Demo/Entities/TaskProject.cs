using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.Autorizations;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.ModelData;
using System.Collections.Generic;

namespace GenericWinForm.Demo.Entities
{

    /// <summary>
    /// this class must contrain All Feild with all configuration posibility
    /// this class must contain All C# Type
    /// becuase it is used to test All Gwin Fields and Components
    /// </summary>
    [DisplayEntity(Localizable =true,DisplayMember = nameof(TaskProject.Title))]
    [Menu]
    public class TaskProject : BaseEntity
    {
        /// <summary>
        /// Type : String
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Title { set; get; }

        /// <summary>
        /// Type : String with MultiLine
        /// </summary>
        [EntryForm(MultiLine =true)]
        [Filter]
        [DataGrid]
        public string Description { set; get; }

        /// <summary>
        /// Type : DateTime
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public System.DateTime StartDate { set; get; }


        /// <summary>
        /// Type : Boolean
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public System.Boolean Valide { set; get; }


        /// <summary>
        /// Type : Int32
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public System.Int32 DaysNumber { set; get; }

        /// <summary>
        /// Type : Int16
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public System.Int16 var_Int16 { set; get; }

        /// <summary>
        /// Type : Int64
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public System.Int64 var_Int64 { set; get; }

        /// <summary>
        /// Type : var_float
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public float var_float { set; get; }

        /// <summary>
        /// Type : double
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public double var_double { set; get; }
 

        /// <summary>
        /// Type : LocalizedString
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        public LocalizedString LocalizedTitle { set; get; }

        

      
        /// <summary>
        /// Type : String Wtih DataSource
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        [DataSource(TypeObject = typeof(ModelConfiguration),
            MethodeName = nameof(ModelConfiguration.GetAll_Entities_Type),
            DisplayName = "Name")]
        public string EntityToManimulate { set; get; }

        /// <summary>
        /// Type : Enumeration
        /// </summary>
        [EntryForm]
        // [Filter] Enumeation in Filter not yet implmented
        [DataGrid]
        public TaskCategory Categoy { set; get; }

        /// <summary>
        /// Type : ManyToOne
        /// </summary>
        [EntryForm]
        [Filter]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public Project Project { set; get; }

        /// <summary>
        /// Type : ManyToManu_Creation
        /// Filter : NotImplemented yet
        /// </summary>
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public virtual List<Individual> Responsibles { set; get; }

        /// <summary>
        /// Type : ManyToMany_Selection 
        /// Filter : NotImplemented yet
        /// </summary>
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public virtual List<Individual> Peoples { set; get; }
    }
}

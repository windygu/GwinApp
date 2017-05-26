GwinApp is rapid C# WinFrom framework with EF6 and Metroframework to create Windows Application with minimum effort.

It use attributes to configure Entity-Manager Interface.

Exemple to Create Group Manager in GwinApp

    [GwinEntity(Localizable =true,DisplayMember = "Name")]
    [Menu(Group= "Trainee")]
    public class Group : BaseEntity
    {
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Name { set; get; }
        
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Description { set; get; }
    }

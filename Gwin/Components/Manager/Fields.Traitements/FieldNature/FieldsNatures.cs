using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.FieldsTraitements.Enumerations
{
    /// <summary>
    /// Field Type suported by Gwin Application
    /// 
    /// </summary>
    public enum FieldsNatures
    {
        // Must add Test into  DetermineFieldNature() methode in BaseFieldTraitement

        Default,
        String,
        Int32,
        Int64,
        Bool,
        StringWithDataSource,
        LocalizedString,
        DateTime,
        Enumeration,
        ManyToMany_Creation,
        ManyToMany_Selection,
        ManyToOne
    }
}

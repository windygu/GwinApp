
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.FieldsTraitements
{
    public class Int64FieldTraitement : Int32FieldTraitement, IFieldTraitements
    {
        public override object GetTestValue(PropertyInfo propertyInfo)
        {
            Int64 value = 5;
            return value;
        }
    }
}

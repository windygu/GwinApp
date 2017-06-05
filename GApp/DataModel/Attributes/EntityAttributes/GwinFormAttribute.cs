using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Attributes
{
    public class GwinFormAttribute : Attribute
    {
        /// <summary>
        /// Type of EntryForm
        /// </summary>
        public Type FormType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Attributes
{
    public class PresentationLogicAttribute : Attribute
    {
        /// <summary>
        /// Presentation logic object type
        /// </summary>
        public Type TypePLO { get; set; }
    }
}

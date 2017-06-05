using GApp.GwinApp.Exceptions.Gwin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.GwinApplication.Security.Exception
{
    class GwinAccessException : GwinException
    {
        public GwinAccessException(string message) : base(message)
        {
        }
    }
}

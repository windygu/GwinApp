using App.Gwin.Exceptions.Gwin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Exceptions.Helpers
{
    public class CheckPramIsNull
    {
        /// <summary>
        /// Check if the parameter is not null
        /// and throw GwinNullParameterExcetion if it is nul
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="ObjectName"></param>
        /// <param name="ParameterName"></param>
        public static void CheckParam_is_NotNull(object Value, object sender, string ParameterName)
        {
            if (Value == null)
            {
                string msg_exception = "The parameter ";
                msg_exception += ParameterName;
                msg_exception +=" must not be Null in ";
                msg_exception += sender.GetType().Name;
                throw new GwinNullParameterException(msg_exception);
            }
        }
    }
}

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Logging
{
    /// <summary>
    /// Loggin Exemple Usign Castel.WinSor Library
    /// </summary>
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            Console.WriteLine(string.Format("Entered Method:{0}, Arguments: {1}", methodName, string.Join(",", invocation.Arguments)));
            invocation.Proceed();
            Console.WriteLine(string.Format("Sucessfully executed method:{0}", methodName));

        }
    }
}

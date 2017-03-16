using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Logging
{
    /// <summary>
    /// Security Implementation
    /// </summary>
    public class SecurityInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            // Security Test


            invocation.Proceed();

        }
    }
}
 

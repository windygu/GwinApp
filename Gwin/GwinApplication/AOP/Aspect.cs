using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.GwinApplication.AOP
{
    /// <summary>
    /// Abstract class to wrap Castle Windsor's IInterceptor to only fire if the method or class is decorated with this attribute.
    /// </summary>
    public abstract class Aspect : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            // Here we want to only run permissions checks against public methods
            // This means we don't subsequentially duplicate the calls against private methods
            // internal to the class.
            if (!invocation.Method.IsPublic)
            {
                // Run the intercepted method as normal.
                invocation.Proceed();
                return;
            }

            if (!CanIntercept(invocation, GetType()))
            {//method is NOT decorated with the proper aspect, continue as normal
                invocation.Proceed();
                return;
            }
            ProcessInvocation(invocation);
        }

        /// <summary>
        /// Determine if the intercepted class or method is decorated with the current attribute
        /// Classes decorated will process if decorated on ALL methods
        /// Methods decorated will process if decorate
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool CanIntercept(IInvocation invocation, Type type)
        {

            // Read autorization attribute
            //AuthorizeAttribute authorize = null;
            //object[] AuthorizeAttributes = invocation.Method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            //if (AuthorizeAttributes != null && AuthorizeAttributes.Count() > 0)
            //{
            //    authorize = (AuthorizeAttribute)AuthorizeAttributes[0];
            //}

            object[] Entity_Attributes = invocation.TargetType.GetCustomAttributes(true);
            object[] Methode_Attributes = invocation.MethodInvocationTarget.GetCustomAttributes(true);

            return Entity_Attributes.Any(x => x.GetType() == type) ||
                Methode_Attributes.Any(x => x.GetType() == type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void ProcessInvocation(IInvocation invocation);
    }

}

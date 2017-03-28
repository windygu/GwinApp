using App.Gwin.Application.BAL;
using App.Gwin.Application.Presentation.Messages;
using App.Gwin.Exceptions.Gwin;
using App.Gwin.GwinApplication.Security.Attributes;
using App.Gwin.GwinApplication.Security.Exception;
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

            invocation.Proceed();

            //// Check autorization attribute
            //AuthorizeAttribute authorize = null;
            //object[] AuthorizeAttributes = invocation.Method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            //if (AuthorizeAttributes != null && AuthorizeAttributes.Count() > 0)
            //{
            //    authorize = (AuthorizeAttribute)AuthorizeAttributes[0];
            //}

            //if(authorize == null)
            //{
            //    // Execution witout autorization
            //    invocation.Proceed();
            //    return;
            //}
            //else
            //{
            //    IGwinBaseBLO blo = (IGwinBaseBLO)Activator.CreateInstance(invocation.Method.DeclaringType, GwinApp.Instance.TypeDBContext);
            //    String EntityReference = blo.ConfigEntity.TypeOfEntity.FullName;

            //    // Check autorization
            //    if (GwinApp.Instance.user.HasAccess(EntityReference, invocation.Method.Name))
            //        invocation.Proceed();
            //    else
            //    {
            //        string msg = String.Format("You d'ont have permission to execute the action {0} in business object {1}",
            //            invocation.Method.Name, EntityReference);
            //        // throw new GwinAccessException();
            //        MessageToUser.AddMessage(MessageToUser.Category.BusinessRule, msg);
            //    }
            //}

           

        }
    }
}


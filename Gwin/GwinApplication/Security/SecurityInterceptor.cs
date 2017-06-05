using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Application.Presentation.Messages;
using GApp.GwinApp.Entities.Secrurity.Authentication;
using GApp.GwinApp.Exceptions.Gwin;
using GApp.GwinApp.GwinApplication.AOP;
using GApp.GwinApp.GwinApplication.Security.Attributes;
using GApp.GwinApp.GwinApplication.Security.Exception;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Security
{
    /// <summary>
    /// Security Implementation
    /// </summary>
    public class SecurityAspect : Aspect
    {

        public override void ProcessInvocation(IInvocation invocation)
        {

            // Create Business Instance 
            IGwinBaseBLO blo = (IGwinBaseBLO)Activator.CreateInstance(invocation.Method.DeclaringType, GwinAppInstance.Instance.TypeDBContext);
            String EntityReference = blo.ConfigEntity.TypeOfEntity.FullName;



            if (AttributeExistsOnMethodOrEntity<DoNotPerformPermissionCheck>(invocation, blo.TypeEntity))
            {
                // Run the intercepted method as normal.
                invocation.Proceed();
                return;
            }

            // Check autorization
            if (GwinAppInstance.Instance.user.Reference == nameof(User.Users.Root) || GwinAppInstance.Instance.user.HasAccess(EntityReference, invocation.Method.Name))
                invocation.Proceed();
            else
            {

                string msg = String.Format("You d'ont have permission to execute the action {0} in business object {1}",
                    invocation.Method.Name, EntityReference);
                throw new GwinAccessException(msg);
                // MessageToUser.AddMessage(MessageToUser.Category.BusinessRule, msg);
            }
        }

        //public void old(IInvocation invocation)
        //{
        //    var methodName = invocation.Method.Name;

        //    // invocation.Proceed();

        //    // Read autorization attribute
        //    AuthorizeAttribute authorize = null;
        //    object[] AuthorizeAttributes = invocation.Method.GetCustomAttributes(typeof(AuthorizeAttribute), true);
        //    if (AuthorizeAttributes != null && AuthorizeAttributes.Count() > 0)
        //    {
        //        authorize = (AuthorizeAttribute)AuthorizeAttributes[0];
        //    }

        //    // Execute Methode if d'ont have autorise attribute
        //    if (authorize == null)
        //    {
        //        invocation.Proceed();
        //        return;
        //    }

        //    // check autorization of cuurent user
        //    else
        //    {
        //        // Create Business Instance 
        //        IGwinBaseBLO blo = (IGwinBaseBLO)Activator.CreateInstance(invocation.Method.DeclaringType, GwinApp.Instance.TypeDBContext);
        //        String EntityReference = blo.ConfigEntity.TypeOfEntity.FullName;

        //        // Check autorization
        //        if (GwinApp.Instance.user.HasAccess(EntityReference, invocation.Method.Name))
        //            invocation.Proceed();
        //        else
        //        {

        //            string msg = String.Format("You d'ont have permission to execute the action {0} in business object {1}",
        //                invocation.Method.Name, EntityReference);
        //            // throw new GwinAccessException();
        //            MessageToUser.AddMessage(MessageToUser.Category.BusinessRule, msg);
        //        }
        //    }



        //}

        private static bool AttributeExistsOnMethodOrEntity<AttributeToCheck>(IInvocation invocation, Type TypeEntity)
        {

            var EntityAttributeExist = TypeEntity.GetCustomAttributes(true).Any(a => a.GetType() == typeof(AttributeToCheck));

            var MethodeAttribute = Attribute.GetCustomAttribute(
                                invocation.Method,
                                typeof(AttributeToCheck),
                                true);

            return MethodeAttribute != null || EntityAttributeExist;
        }

    }
}


using App.Gwin.Application.BAL;
using App.Gwin.Entities;
using App.Gwin.Entities.ContactInformations;
using App.Gwin.Logging;
using App.Gwin.ModelData;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System;

namespace App.Gwin.GwinApplication.IoC
{
    public class ComponentRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
            kernel.Register(
                Component.For<LoggingInterceptor>()
                    .ImplementedBy<LoggingInterceptor>());

            // Registrer All BLO Objects
            foreach (Type EntityType in new ModelConfiguration().GetAll_Entities_Type())
            {

                Type ServiceType = GwinBaseBLO<BaseEntity>.Detemine_Type_EntityBLO(EntityType, GwinApp.Instance.TypeBaseBLO);

                kernel.Register(
              Component.For(ServiceType).ImplementedBy(ServiceType)
                       .Interceptors(InterceptorReference.ForType<LoggingInterceptor>()).Anywhere);
            }
          
        }
    }
}

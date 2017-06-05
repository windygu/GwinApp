using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.DataModel.ModelInfo;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Logging;
using GApp.GwinApp.ModelData;
using GApp.GwinApp.Security;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System;

namespace GApp.GwinApp.GwinApplication.IoC
{
    public class ComponentRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
           

            //kernel.Register(
            //    Component.For<SecurityInterceptor>()
            //        .ImplementedBy<SecurityInterceptor>());

            kernel.Register(Component.For<SecurityAspect>());
            kernel.Register(Component.For<LoggingAspect>());

          

            // Registrer All BLO Objects
            foreach (Type EntityType in new GwinEntitiesManager().GetAll_Entities_Type())
            {

                Type BLOEntity_Type = GwinBaseBLO<BaseEntity>.Detemine_Type_EntityBLO(EntityType, GwinAppInstance.Instance.TypeBaseBLO);


                //   kernel.Register(
                //Component.For(BLOEntity_Type).ImplementedBy(BLOEntity_Type)
                //         .Interceptors(
                //    InterceptorReference.ForType<SecurityInterceptor>()).Anywhere);

                kernel.Register(
              Component.For(BLOEntity_Type).ImplementedBy(BLOEntity_Type)
              .Interceptors(
                  typeof(SecurityAspect),
                  typeof(LoggingAspect)));

            }

        }
    }
}

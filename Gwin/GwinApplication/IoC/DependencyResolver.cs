using App.Gwin.Application.BAL;
using Castle.Windsor;
using System;

namespace App.Gwin.GwinApplication.IoC
{
    /// <summary>
    /// WindsorContainer
    /// </summary>
    public class DependencyResolver
    {
        private static IWindsorContainer _container;

        //Initialize the container
        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Register(new ComponentRegistration());
        }

        //Resolve types
        public static T For<T>()
        {
            return _container.Resolve<T>();
        }

        public static object For(Type Service)
        {
            return _container.Resolve(Service);
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using CaliburnCastleEFDemo2.DataLayer;
using CaliburnCastleEFDemo2.ViewModels;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CaliburnCastleEFDemo2
{
   public class Bootstrapper : Bootstrapper<ShellViewModel>
   {
      private IWindsorContainer _container;

      protected override void Configure()
      {
         _container = new WindsorContainer();

         // register components here
         _container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());
         _container.Register(
            Component.For<IEventAggregator>().ImplementedBy<EventAggregator>().LifeStyle.Is(LifestyleType.Singleton));
         _container.AddFacility<TypedFactoryFacility>();

         _container.Register(Component.For<IEmployeeRepository>().ImplementedBy<EmployeeRepository>());
         
         // this allows registering views with viewmodels if viewmodels are in another assembly/library
         _container.Register(AllTypes.FromAssembly(typeof(ShellViewModel).Assembly)
            .Where(x => x.Name.EndsWith("ViewModel") || x.Name.EndsWith("View"))
            .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
      }

      // needed if views and viewmodels are in a seperate assembly
      protected override IEnumerable<Assembly> SelectAssemblies()
      {
         return new[]
                   {
                      Assembly.GetExecutingAssembly(),
                      typeof(ShellViewModel).Assembly
                   };
      }

      protected override object GetInstance(Type service, string key)
      {
         return string.IsNullOrWhiteSpace(key)
         ? _container.Resolve(service)
         : _container.Resolve(key, service);
      }

      protected override IEnumerable<object> GetAllInstances(Type service)
      {
         return (IEnumerable<object>)_container.ResolveAll(service);
      }

      protected override void BuildUp(object instance)
      {
         Extensions.ForEach(instance.GetType().GetProperties()
                     .Where(property => property.CanWrite && property.PropertyType.IsPublic)
                     .Where(property => _container.Kernel.HasComponent(property.PropertyType)),
                     property => property.SetValue(instance, _container.Resolve(property.PropertyType), null));
      }
   }
}

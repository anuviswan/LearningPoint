using Automapper.UseIoc.ViewModels;
using AutoMapper;
using Caliburn.Micro;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Automapper.UseIoc
{
    public class BootstrapperUsingUnity : BootstrapperBase
    {
        private IUnityContainer _unityContainer;
        #region Constructor
        public BootstrapperUsingUnity()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterInstance<IWindowManager>(new WindowManager());
            _unityContainer.RegisterInstance<IEventAggregator>(new EventAggregator(), new ContainerControlledLifetimeManager());


            var mapper = MappingProfile.InitializeAutoMapper(_unityContainer).CreateMapper();
            _unityContainer.RegisterInstance<IMapper>(mapper);

            _unityContainer.RegisterType<Person>(new InjectionProperty(nameof(Person.FirstName), "Unknown Person First Name"),
                                     new InjectionProperty(nameof(Person.LastName), "Unknown Person LastName Name"),
                                     new InjectionProperty(nameof(Person.Age), 32));

            _unityContainer.RegisterType<Address>(new InjectionProperty(nameof(Address.Street), "Unknown Street"),
                         new InjectionProperty(nameof(Address.City), "Unknown City"),
                         new InjectionProperty(nameof(Address.State), "Unknown State"),
                         new InjectionProperty(nameof(Address.Country), "Unknown Country"));

            _unityContainer.RegisterType<Student>(new InjectionProperty(nameof(Student.FirstName), "Unknown Student First Name"),
                                     new InjectionProperty(nameof(Student.LastName), "Unknown Student LastName Name"),
                                     new InjectionProperty(nameof(Student.School), "Unknown Student School"),
                                     new InjectionProperty(nameof(Student.Age), 32));


            //View Models
            _unityContainer.RegisterType<ShellViewModel>(new InjectionConstructor(_unityContainer.Resolve<IMapper>()));
        }

        protected override void BuildUp(object instance)
        {
            _unityContainer.BuildUp(instance);
            base.BuildUp(instance);
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? _unityContainer.Resolve(service, key) : _unityContainer.Resolve(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _unityContainer.ResolveAll(service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        #endregion
    }

    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper(IUnityContainer container)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(type => container.Resolve(type));
                cfg.AddProfile(new AssemblyProfile());

            });

            return config;
        }
    }
}

﻿using App006.CustomEventAggregator.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace App006.CustomEventAggregator
{
    public class BootstrapperUnity : BootstrapperBase
    {
        private IUnityContainer _unityContainer;
        #region Constructor
        public BootstrapperUnity()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {
            _unityContainer = new UnityContainer();
            IoC.GetInstance = GetInstance;
            _unityContainer.RegisterInstance<IWindowManager>(new WindowManager());
            _unityContainer.RegisterInstance<IEventAggregator>(new EventAggregator(), new ContainerControlledLifetimeManager());

            //View Models
             _unityContainer.RegisterInstance<ShellViewModel>(new ShellViewModel());
            
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
}

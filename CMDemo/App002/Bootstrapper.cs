using App002.Contracts;
using App002.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App002
{
    public class Bootstrapper : BootstrapperBase 
    {
        #region Private Variables
        private SimpleContainer _Container = new SimpleContainer();
        #endregion

        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        } 
        #endregion

        protected override object GetInstance(Type service, string key)
        {
            return _Container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _Container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _Container.BuildUp(instance);
        }

        protected override void Configure()
        {
            _Container.Instance<IWindowManager>(new WindowManager());
            _Container.Singleton<IEventAggregator, EventAggregator>();
            _Container.PerRequest<IShellViewModel, ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<IShellViewModel>();
        }
    }
}

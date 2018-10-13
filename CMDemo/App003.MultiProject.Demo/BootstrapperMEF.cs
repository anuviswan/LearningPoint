using App003.MultiProject.Demo.Library.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App003.MultiProject.Demo
{
    public class BootstrapperMEF : BootstrapperBase
    {
        #region Private Variables
        private CompositionContainer _Container;
        #endregion

        #region Constructor
        public BootstrapperMEF()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {
            string pluginPath = AppDomain.CurrentDomain.BaseDirectory;

            var fi = new DirectoryInfo(pluginPath).GetFiles("*.dll");
            AssemblySource.Instance.AddRange(fi.Select(fileInfo => Assembly.LoadFrom(fileInfo.FullName)));

            var catalog = new AggregateCatalog(
                AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                );

            _Container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_Container);

            _Container.Compose(batch);
        }

        protected override object GetInstance(Type service, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = _Container.GetExportedValues<object>(contract);
            if (exports.Any())
                return exports.First();
            else
                throw new Exception("Could not find the key");
        }

        protected override void BuildUp(object instance)
        {
            _Container.SatisfyImportsOnce(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _Container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
        #endregion
    }
}

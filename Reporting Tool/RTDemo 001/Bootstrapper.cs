using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RTDemo_001
{
    public class Bootstrapper:BootstrapperBase
    {
        #region Private Variables
        private CompositionContainer _container;
        #endregion

        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides

        protected override void Configure()
        {
            _container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.SatisfyImportsOnce(this);
            _container.Compose(batch);
        }

        protected override object GetInstance(Type service, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = _container.GetExportedValues<object>(contract);
            return exports.Any() ? exports.First():throw new Exception("Could not find the key");
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<IShellViewModel>();
        }
        #endregion
    }
}

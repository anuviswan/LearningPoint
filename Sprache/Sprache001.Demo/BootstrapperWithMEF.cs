using Caliburn.Micro;
using Sprache001.Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sprache001.Demo
{
    public class BootstrapperWithMEF : BootstrapperBase
    {
        #region Private Variables
        private CompositionContainer _Container;
        #endregion

        #region Constructor
        public BootstrapperWithMEF()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void Configure()
        {

            _Container = new CompositionContainer(
                new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>())
                );
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
            DisplayRootViewFor<ShellViewModel>();
        }
        #endregion
    }
}

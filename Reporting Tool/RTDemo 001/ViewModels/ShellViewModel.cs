using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Enums;
using RTDemo_001.Models;
using RTDemo_001.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using Application = System.Windows.Application;


namespace RTDemo_001.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<object>, IShellViewModel, IHandle<DataEventModel>
    {

        #region Private Variables
        private readonly IDataViewModel _dataVm;
        private readonly IPreviewDataViewModel _previewDataVm;
        private IList<ProductModel> _productCollecton;
        [ImportMany]
        public IEnumerable<Lazy<IReportViewerViewModel, IReportMetaData>> ViewerFactory { get; set; }
        [ImportMany]
        public IEnumerable<Lazy<IReportDesignerViewModel, IReportMetaData>> DesignerFactory { get; set; }
        #endregion

        #region Constructor
        [ImportingConstructor]
        public ShellViewModel(IDataViewModel dataVm,
                                IPreviewDataViewModel previewDataVm,
                                IEventAggregator eventAggregator)
        {
            _dataVm = dataVm;
            _previewDataVm = previewDataVm;
            eventAggregator.Subscribe(this);
        }
        #endregion

        #region IShellViewModel
        public void CloseApplication() => Application.Current.Shutdown();
        public void CreateMockData() => ActivateItem(_dataVm);
        public void Handle(DataEventModel message) => _productCollecton = message.ProductCollection;
        public void ShowDesigner(EReportingTool reportingTool, bool isModal)
        {
            if (!(GetDesigner(reportingTool) is IReportDesignerViewModel designerVm)) return;

            ActivateItem(designerVm);
            designerVm.Show(isModal, _productCollecton);
        }

        public void ViewMockData()  => ActivateItem(_previewDataVm);
        public void ViewReport(EReportingTool reportingTool, bool isModal)
        {
            if (!(GetViewer(reportingTool) is IReportViewerViewModel viewerVm)) return;

            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = viewerVm.FileFilter };
            if (ofd.ShowDialog() != true) return;
            ActivateItem(viewerVm);
            viewerVm.Show(ofd.FileName, isModal, _productCollecton);
        }
        #endregion

        #region Private Methods
        private IReportViewerViewModel GetViewer(EReportingTool reportingTool)
        {
            if (ViewerFactory.Any(x => x.Metadata.ReportId == reportingTool))
                return ViewerFactory.First(x => x.Metadata.ReportId == reportingTool).Value;

            MessageBox.Show(Resources.ShellViewModel_GetViewer_Not_Implemented);
            return null;
        }
        private IReportDesignerViewModel GetDesigner(EReportingTool reportingTool)
        {
            if(DesignerFactory.Any(x => x.Metadata.ReportId == reportingTool))
                return DesignerFactory.First(x => x.Metadata.ReportId == reportingTool).Value;

            MessageBox.Show(Resources.ShellViewModel_GetViewer_Not_Implemented);
            return null;
        }
        #endregion
    }
}

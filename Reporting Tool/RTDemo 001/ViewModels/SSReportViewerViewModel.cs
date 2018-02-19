using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Utils;
using System.Collections.Generic;

namespace RTDemo_001.ViewModels
{
    [ExportReportViewerTagAttribute(Enums.EReportingTool.StimulsoftReports)]
    public class SSReportViewerViewModel : Screen, IReportViewerViewModel
    {
        #region Private Variables
        private const string XProducts = "Products";
        private Stimulsoft.Report.StiReport _stiReport;
        #endregion

        public Stimulsoft.Report.StiReport CurrentReport
        {
            get => _stiReport;
            set
            {
                _stiReport = value;
                NotifyOfPropertyChange(nameof(CurrentReport));
            }
        }

        private bool _showControl;
        public bool ShowControl
        {
            get => _showControl;
            set
            {
                this._showControl = value;
                NotifyOfPropertyChange(nameof(ShowControl));
            }
        }




        #region IReportViewerViewModel
        public string FileFilter => Constants.XSsFileFilter;

        public void Show<T>(string fileName, bool isModal, IList<T> collection)
        {
            this.RegisterData(collection);
            this.ShowControl = !isModal;
            if (isModal)
            {
                CurrentReport.Load(fileName);
                CurrentReport.ShowWithWpf();
            }
            else
            {
                this.CurrentReport.Load(fileName);
                this.CurrentReport.RenderWithWpf();
                this.CurrentReport.InvokeRefreshViewer();

                NotifyOfPropertyChange(nameof(CurrentReport));
                
            }
        }

        public void RegisterData<T>(IList<T> productCollection)
        {
            CurrentReport = new Stimulsoft.Report.StiReport();
            CurrentReport.RegBusinessObject(XProducts, productCollection);
            CurrentReport.Dictionary.SynchronizeBusinessObjects(5);
        }
        #endregion
    }
}

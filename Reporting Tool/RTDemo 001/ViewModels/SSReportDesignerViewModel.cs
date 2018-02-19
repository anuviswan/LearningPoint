using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using RTDemo_001.Utils;
using Stimulsoft.Report;
using System.Collections.Generic;

namespace RTDemo_001.ViewModels
{
    [ExportReportDesignerTag(Enums.EReportingTool.StimulsoftReports)]
    public class SSReportDesignerViewModel : Screen, IReportDesignerViewModel
    {
        #region Variables
        private bool _showDesignerControl;
        protected const string XProducts = "Products";
        #endregion

        public bool DesignerControl
        {
            get => _showDesignerControl;
            set
            {
                _showDesignerControl = value;
                NotifyOfPropertyChange(nameof(DesignerControl));
            }
        }



        private StiReport _activeReport;

        public StiReport ActiveReport
        {
            get => _activeReport;
            set
            {
                _activeReport = value;
                NotifyOfPropertyChange(nameof(ActiveReport));
            }
        }




        #region IReportDesignerViewModel

        public void Show<T>(bool isModal, IList<T> productCollection)
        {
            RegisterData((IList<ProductModel>)productCollection);
            DesignerControl = !isModal;

            if (isModal)
                ActiveReport.DesignWithWpf();
            else
                ActiveReport.RenderWithWpf();
           
        }
        

        public void RegisterData<T>(IList<T> productCollection)
        {
            ActiveReport = new StiReport();
            ActiveReport.Dictionary.Clear();
            ActiveReport.RegBusinessObject(XProducts, productCollection);
            ActiveReport.Dictionary.SynchronizeBusinessObjects(5);
        }
        #endregion


    }
}

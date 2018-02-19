using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using RTDemo_001.Utils;
using System.Collections.Generic;

namespace RTDemo_001.ViewModels
{
    [ExportReportViewerTagAttribute(Enums.EReportingTool.Rdlc)]
    public class RDLCReportViewerViewModel : Screen, IReportViewerViewModel
    {
        #region Private Variables
        private IList<ProductModel> _productCollection;
        private ISupervisingController _view;
        #endregion

        #region IReporterViewModel
        public string FileFilter => Constants.XRdlcFileFilter;

        public void RegisterData<T>(IList<T> productCollection)
        {
            _productCollection = productCollection as IList<ProductModel>;
        }

        public void Show<T>(string fileName, bool isModal, IList<T> collection)
        {
            RegisterData(collection);
            _view.AttachReport(_productCollection, fileName);

        }
        #endregion

        #region Overrides

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            _view = view as ISupervisingController;
        }
        #endregion
    }
}

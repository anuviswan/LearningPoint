using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using RTDemo_001.Utils;
using System.Collections.Generic;

namespace RTDemo_001.ViewModels
{

    [ExportReportViewerTagAttribute(Enums.EReportingTool.CrystalReport)]
    public class CRReportViewerViewModel : Screen, IReportViewerViewModel
    {
        #region Private Variables
        private ISupervisingController _supervisingController;
        private IList<ProductModel> _productCollection;
        #endregion
        

        #region IReportViewViewModel
        public string FileFilter => Constants.XCrFileFilter;

        public void RegisterData<T>(IList<T> productCollection)
        {
            _productCollection = productCollection as IList<ProductModel>;
        }

        public void Show<T>(string fileName, bool isModal, IList<T> collection)
        {
            RegisterData(collection);
            _supervisingController.AttachReport(_productCollection, fileName);
        }
        #endregion


        #region Overrides
        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            _supervisingController = view as ISupervisingController;
        }

        #endregion
    }
}

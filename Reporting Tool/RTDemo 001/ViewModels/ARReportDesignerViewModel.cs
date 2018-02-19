using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Utils;
using System;
using System.Collections.Generic;

namespace RTDemo_001.ViewModels
{
    [ExportReportDesignerTag(Enums.EReportingTool.ActiveReport)]
    public class ARReportDesignerViewModel : Screen, IReportDesignerViewModel
    {

        // Not Implemented.
        #region IReportDesignerViewModel

        public void RegisterData<T>(IList<T> productCollection)
        {
            throw new NotImplementedException();
        }

        public void Show<T>(bool isModal, IList<T> productCollection)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}

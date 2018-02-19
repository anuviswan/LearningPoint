using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Utils;

namespace RTDemo_001.ViewModels
{
    // List & Label Reporting
    [ExportReportViewerTagAttribute(Enums.EReportingTool.ListAndLabel)]
    public class LLReportViewerViewModel : Screen, IReportViewerViewModel
    {
        public void RegisterData<T>(IList<T> productCollection)
        {
            throw new NotImplementedException();
        }

        public string FileFilter { get; }
        public void Show<T>(string fileName, bool isModal, IList<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}

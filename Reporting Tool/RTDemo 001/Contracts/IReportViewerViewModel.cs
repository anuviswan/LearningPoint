using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface IReportViewerViewModel:IReport
    {
        string FileFilter { get;}
        void Show<T>(string fileName,bool isModal, IList<T> collection);
    }
}

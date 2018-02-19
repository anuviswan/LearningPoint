using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface IReportDesignerViewModel:IReport
    {
        void Show<T>(bool isModal,IList<T> productCollection);
    }
}

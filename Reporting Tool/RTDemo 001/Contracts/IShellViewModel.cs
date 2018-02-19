using RTDemo_001.Enums;

namespace RTDemo_001.Contracts
{

    public interface IShellViewModel
    {
        void CreateMockData();
        void ViewMockData();
        void ShowDesigner(EReportingTool reportingTool, bool isModal);
        void ViewReport(EReportingTool reportingTool, bool isModal);
        void CloseApplication();
    }
}

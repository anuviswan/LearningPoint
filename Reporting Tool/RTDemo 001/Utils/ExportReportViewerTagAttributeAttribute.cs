using RTDemo_001.Contracts;
using RTDemo_001.Enums;
using System;
using System.ComponentModel.Composition;

namespace RTDemo_001.Utils
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportReportViewerTagAttributeAttribute:ExportAttribute, IReportMetaData
    {
        public EReportingTool ReportId { get;  }

        public ExportReportViewerTagAttributeAttribute(EReportingTool reportViewerId) : base(typeof(IReportViewerViewModel)) => ReportId = reportViewerId;
    }
}

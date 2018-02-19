using RTDemo_001.Contracts;
using RTDemo_001.Enums;
using System;
using System.ComponentModel.Composition;

namespace RTDemo_001.Utils
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportReportDesignerTagAttribute : ExportAttribute, IReportMetaData
    {
        public EReportingTool ReportId { get; }

        public ExportReportDesignerTagAttribute(EReportingTool reportViewerId) : base(typeof(IReportDesignerViewModel)) => ReportId = reportViewerId;
    }
}

using RTDemo_001.Contracts;
using RTDemo_001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTDemo_001.Views
{
    /// <summary>
    /// Interaction logic for RDLCReportViewerView.xaml
    /// </summary>
    public partial class RDLCReportViewerView : UserControl, ISupervisingController
    {
        public RDLCReportViewerView()
        {
            InitializeComponent();
        }

        public void AttachReport(IList<ProductModel> ProductCollection,string FileName)
        {
            Microsoft.Reporting.WinForms.ReportDataSource source = new Microsoft.Reporting.WinForms.ReportDataSource();
            source.Name = "BusinessDataSet";
            source.Value = ProductCollection;

            RDLCViewer.LocalReport.DataSources.Add(source);
            RDLCViewer.LocalReport.ReportPath = FileName;
            RDLCViewer.RefreshReport();
        }
    }
}

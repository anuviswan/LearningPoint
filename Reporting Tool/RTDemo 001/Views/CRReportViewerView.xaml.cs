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
    /// Interaction logic for CRReportViewerView.xaml
    /// </summary>
    public partial class CRReportViewerView : UserControl, ISupervisingController
    {
        public CRReportViewerView()
        {
            InitializeComponent();
        }

        public void AttachReport(IList<ProductModel> ProductCollection, string FileName)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report.Load(FileName);

            report.SetDataSource(ProductCollection);

            CRViewer.ViewerCore.ReportSource = report;
        }
    }
}

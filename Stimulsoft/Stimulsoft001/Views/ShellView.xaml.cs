using Stimulsoft001.Contracts;
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
using System.Windows.Shapes;
using Stimulsoft.Report;

namespace Stimulsoft001.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window, ISupervisingController
    {
        public ShellView()
        {
            InitializeComponent();
        }

        #region ISupervisingController
        public void UpdateReportControl(StiReport Report)
        {
            ReportDesigner.Report = Report;
        } 
        #endregion
    }
}

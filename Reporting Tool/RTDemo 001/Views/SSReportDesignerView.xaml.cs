using RTDemo_001.Contracts;
using Stimulsoft.Report;
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
    /// Interaction logic for SSReportDesignerView.xaml
    /// </summary>
    public partial class SSReportDesignerView : UserControl
    {
        
        public SSReportDesignerView()
        {
            //byte[] array = Encoding.UTF8.GetBytes(); // this is the XML file string
            //var stream = new MemoryStream(array);            
            InitializeComponent();
        }
        
    }
}

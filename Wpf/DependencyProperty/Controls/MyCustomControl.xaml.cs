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

namespace DependencyPropertyDemo.Controls
{
    /// <summary>
    /// Interaction logic for MyCustomControl.xaml
    /// </summary>
    public partial class MyCustomControl : UserControl
    {

        public string CustomValue
        {
            get { return (string)GetValue(CustomValueProperty); }
            set { SetValue(CustomValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomValueProperty =
            DependencyProperty.Register(nameof(CustomValue), typeof(string), typeof(MyCustomControl), new PropertyMetadata("Default Value From Dp"));


        public MyCustomControl()
        {
            InitializeComponent();
        }
    }
}

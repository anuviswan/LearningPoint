using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TypeConverters.CustomTypeConverters;

namespace TypeConverters.CustomControls
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
        }


        [TypeConverter(typeof(StringToArrayConverter))]
        public string[] Users
        {
            get => (string[])GetValue(UserProperty);
            set => SetValue(UserProperty, value);
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register(nameof(Users), typeof(string[]), typeof(UserList), new PropertyMetadata(default));


    }
}

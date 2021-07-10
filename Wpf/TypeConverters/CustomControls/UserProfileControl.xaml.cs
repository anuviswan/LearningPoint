using System.Windows;
using System.Windows.Controls;
using TypeConverters.Models;

namespace TypeConverters.CustomControls
{
    /// <summary>
    /// Interaction logic for UserProfileControl.xaml
    /// </summary>
    public partial class UserProfileControl : UserControl
    {
        public UserProfileControl()
        {
            InitializeComponent();
        }

        public UserInfo CurrentUser
        {
            get => (UserInfo)GetValue(UserProperty);
            set => SetValue(UserProperty, value);
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register(nameof(CurrentUser), typeof(UserInfo), typeof(UserProfileControl), new PropertyMetadata(default));
    }
}

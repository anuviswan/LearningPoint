using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DependencyPropertyDemo.Controls
{
    public class ExtendedButtonControl:Button
    {
        public string CustomValue
        {
            get { return (string)GetValue(CustomValueProperty); }
            set { SetValue(CustomValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CustomValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomValueProperty =
            DependencyProperty.Register("CustomValue", typeof(string), typeof(ExtendedButtonControl), new PropertyMetadata("Default Value",new PropertyChangedCallback(CustomValueChanged)));

        private static void CustomValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Button buttonControl)
            {
                buttonControl.Content = e.NewValue;
            }
        }
    }
}

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
            DependencyProperty.Register("CustomValue", typeof(string), typeof(ExtendedButtonControl), new PropertyMetadata("Default Value",new PropertyChangedCallback(CustomValueChanged),new CoerceValueCallback(CoerceCustomValue)));

        private static object CoerceCustomValue(DependencyObject d, object baseValue)
        {
            if (d is ExtendedButtonControl buttonControl && baseValue is string currentValue)
            {
                // This won't work as .Clear() will not trigger CoerceValue
                if (string.Equals("Value From ExtendedButton Style", currentValue))
                {
                    currentValue = "Corrected Value";
                    return currentValue;
                }
            }
            return baseValue;
        }

        private static void CustomValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Button buttonControl)
            {
                buttonControl.Content = e.NewValue;
            }
        }
    }
}

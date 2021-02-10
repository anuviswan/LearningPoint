using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Behavior001.Behaviors
{
    public class TextBoxOnFontHightlightBehavior:Behavior<TextBox>
    {
        private double _fontSize; 
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += GotFocus;
            AssociatedObject.LostFocus += LostFocus;
        }

        private void LostFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox textBox)
            {
                textBox.FontSize = _fontSize;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= GotFocus;
            AssociatedObject.GotFocus -= LostFocus;
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox textBox)
            {
                _fontSize = textBox.FontSize;
                textBox.FontSize += 2;
            }
        }
    }
}

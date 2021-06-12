using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;

namespace DependencyProperty.ViewModels
{
    public class ValueResolutionViewModel:Screen
    {
        public string _buttonValue;
        public string ButtonValue
        {
            get => _buttonValue;
            set
            {
                _buttonValue = value;
                NotifyOfPropertyChange(nameof(ButtonValue));
            }
        }

        public void ClearValue(Button button)
        {
            button.ClearValue(Button.ContentProperty);
        }
    }
}

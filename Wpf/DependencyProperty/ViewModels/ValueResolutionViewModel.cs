using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;

namespace DependencyPropertyDemo.ViewModels
{
    public class ValueResolutionViewModel:Screen
    {
        public string _currentValue;
        public string CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                NotifyOfPropertyChange(nameof(CurrentValue));
            }
        }

        public void ClearValue(Button button)
        {
            button.ClearValue(Button.ContentProperty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CircularProgressbar.ViewModels
{
    public class ShellViewModel : Screen
    {
        private double currentValue = 10;

        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 100;
        public double CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                NotifyOfPropertyChange();
            }
        }

        public void Reset()
        {
            NotifyOfPropertyChange(nameof(MinValue));
            NotifyOfPropertyChange(nameof(MaxValue));
        }
    }
}

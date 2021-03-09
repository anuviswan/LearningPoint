using Caliburn.Micro;

namespace ValueCoercion.ViewModels
{
    public class ShellViewModel:Screen
    {
        private int _minValue = 5;
        private int _maxValue = 11;

        public int MinValue
        {
            get => _minValue;
            set
            {
                if (value == _minValue) return;
                _minValue = value;
                NotifyOfPropertyChange();
            }
        }
        public int MaxValue
        {
            get => _maxValue;
            set
            {
                if (value == _maxValue) return;
                _maxValue = value;
                NotifyOfPropertyChange();
            }
        }
    }
}

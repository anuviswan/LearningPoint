using System.Windows;
using Caliburn.Micro;
using CircularProgressbar.ArcInfoCalculator;
using CircularProgressbar.Models;

namespace CircularProgressbar.ViewModels
{

    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            BackgroundCircle.Angle = 360;
            BackgroundCircle.PropertyChanged += OnBackgroundCircleChanged;
        }

        private void OnBackgroundCircleChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ProgressArc.Thickness):
                    var radius = 50 - BackgroundCircle.Thickness/2;
                    BackgroundCircle.Radius = new Size(radius,radius);
                    BackgroundCircle.EndPosition = (new ArcCalculatorBase()).AngleToPointConverter(radius, 360);
                    BackgroundCircle.StartPosition = (new ArcCalculatorBase()).AngleToPointConverter(radius, 0);
                break;
                default:
                    NotifyOfPropertyChange(e.PropertyName);
                    break;
            }
        }

        public ProgressArc BackgroundCircle { get; set; } = new ProgressArc();
        public ProgressArc ValueCircle { get; set; } = new ProgressArc();
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double CurrentValue { get; set; }
    }
}

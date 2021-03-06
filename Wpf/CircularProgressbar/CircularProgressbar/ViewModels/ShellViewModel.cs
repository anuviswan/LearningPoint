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
            BackgroundCircle.PropertyChanged += OnCircleChanged;
            ValueCircle.PropertyChanged += OnCircleChanged;
            PropertyChanged += OnPropertyChanged; ;
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MaxValue):
                case nameof(MinValue):
                case nameof(CurrentValue):
                case nameof(SelectedOverlayMode):
                    RefreshControl();
                    break;
            }
        }

        private void OnCircleChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RefreshControl();
        }

        private void RefreshControl()
        {
            ArcCalculatorBase arcCalculator;
            switch (SelectedOverlayMode)
            {
                case OverlayMode.Centered:
                    arcCalculator = new CenteredArcCalculator(BackgroundCircle.Thickness, ValueCircle.Thickness); 
                    break;
                case OverlayMode.Inset:
                    arcCalculator = new InsetArcCalculator(BackgroundCircle.Thickness, ValueCircle.Thickness);
                    break;
                case OverlayMode.Outset:
                    arcCalculator = new OutsetArcCalculator(BackgroundCircle.Thickness, ValueCircle.Thickness);
                    break;
                default:
                    arcCalculator = new OutsetArcCalculator(BackgroundCircle.Thickness, ValueCircle.Thickness);
                    break;
            }
            arcCalculator.Calculate(MinValue, MaxValue, CurrentValue);

            BackgroundCircle.Radius = arcCalculator.BackgroundCircleRadius;
            BackgroundCircle.StartPosition = arcCalculator.BackgroundCircleStartPosition;
            BackgroundCircle.EndPosition = arcCalculator.BackgroundCircleEndPosition;

            ValueCircle.Radius = arcCalculator.ValueCircleRadius;
            ValueCircle.StartPosition = arcCalculator.ValueCircleStartPosition;
            ValueCircle.EndPosition = arcCalculator.ValueCircleEndPosition;
        }

        public ProgressArc BackgroundCircle { get; set; } = new ProgressArc();
        public ProgressArc ValueCircle { get; set; } = new ProgressArc();
        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 120;
        public double CurrentValue { get; set; } = 60;

        public OverlayMode SelectedOverlayMode { get; set; }
    }
}

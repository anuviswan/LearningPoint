using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CircularProgressbar_UsingTwinCircles.ViewModels
{
    public class ShellViewModel:Screen
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

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
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
                case OverlayMode.InnerCircle:
                    arcCalculator = new InsetArcCalculator(BackgroundCircle.Thickness, ValueCircle.Thickness);
                    break;
                case OverlayMode.OuterCircle:
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
            ValueCircle.Angle = arcCalculator.ValueAngle;
        }

        public ProgressArc BackgroundCircle { get; set; } = new ProgressArc();
        public ProgressArc ValueCircle { get; set; } = new ProgressArc();
        public double MinValue { get; set; } = 10;
        public double MaxValue { get; set; } = 120;
        public double CurrentValue { get; set; } = 60;

        public OverlayMode SelectedOverlayMode { get; set; }
    }
}

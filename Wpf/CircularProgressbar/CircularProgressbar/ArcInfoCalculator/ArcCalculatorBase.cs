using System;
using System.Windows;

namespace CircularProgressbar.ArcInfoCalculator
{
    public abstract class ArcCalculatorBase
    {
        protected const double ORIGIN = 50;
        protected double _backgroundCircleThickness;
        protected double _valueCircleThickness;
        public ArcCalculatorBase(double backgroundCircleThickness, double valueCircleThickness)
        {
            _backgroundCircleThickness = backgroundCircleThickness;
            _valueCircleThickness = valueCircleThickness;
        }

        public Size BackgroundCircleRadius { get; protected set; }
        public Size ValueCircleRadius { get; protected set; }

        public Point BackgroundCircleStartPosition { get; protected set; }
        public Point BackgroundCircleEndPosition { get; protected set; }

        public Point ValueCircleStartPosition { get; protected set; }
        public Point ValueCircleEndPosition { get; protected set; }

        public double ValueAngle { get; set; }

        protected double GetAngleForValue(double minValue, double maxValue, double currentValue)
        {
            var percent = (currentValue - minValue) * 100 / (maxValue - minValue);
            var valueInAngle = (percent / 100) * 360;
            return valueInAngle;
        }
        public abstract void Calculate(double minValue, double maxValue, double currentValue);
        protected Point GetPointForAngle(Size radiusInSize,double angle)
        {
            var radius = radiusInSize.Height;
            angle = angle == 360 ? 359.99 : angle;
            double angleInRadians = angle * Math.PI / 180;

            double px = ORIGIN + (Math.Sin(angleInRadians) * radius);
            double py = ORIGIN + (-Math.Cos(angleInRadians) * radius);

            return new Point(px, py);
        }
    }

    public class OutsetArcCalculator : ArcCalculatorBase
    {
        public OutsetArcCalculator(double backgroundCircleThickness, double valueCircleThickness):base(backgroundCircleThickness,valueCircleThickness)
        {

        }

        public override void Calculate(double minValue,double maxValue,double currentValue)
        {
            BackgroundCircleRadius =  new Size(ORIGIN - _backgroundCircleThickness / 2, ORIGIN - _backgroundCircleThickness / 2);
            ValueCircleRadius = new Size(ORIGIN - _valueCircleThickness / 2, ORIGIN - _valueCircleThickness / 2); ;

            BackgroundCircleStartPosition = GetPointForAngle(BackgroundCircleRadius, 0);
            BackgroundCircleEndPosition = GetPointForAngle(BackgroundCircleRadius, 360);

            ValueAngle = GetAngleForValue(minValue, maxValue, currentValue);

            ValueCircleStartPosition = GetPointForAngle(ValueCircleRadius, 0);
            ValueCircleEndPosition = GetPointForAngle(ValueCircleRadius, ValueAngle);
        }
    }

    public class CenteredArcCalculator : ArcCalculatorBase
    {
        public CenteredArcCalculator(double backgroundCircleThickness, double valueCircleThickness) : base(backgroundCircleThickness, valueCircleThickness)
        {

        }

        public override void Calculate(double minValue, double maxValue, double currentValue)
        {
            var maxThickness = Math.Max(_backgroundCircleThickness, _valueCircleThickness);
            
            BackgroundCircleRadius = new Size(ORIGIN - maxThickness / 2, ORIGIN - maxThickness / 2);
            ValueCircleRadius = new Size(ORIGIN - maxThickness / 2, ORIGIN - maxThickness / 2); ;

            BackgroundCircleStartPosition = GetPointForAngle(BackgroundCircleRadius, 0);
            BackgroundCircleEndPosition = GetPointForAngle(BackgroundCircleRadius, 360);

            ValueAngle = GetAngleForValue(minValue, maxValue, currentValue);

            ValueCircleStartPosition = GetPointForAngle(ValueCircleRadius, 0);
            ValueCircleEndPosition = GetPointForAngle(ValueCircleRadius, ValueAngle);
        }
    }

    public class InsetArcCalculator : ArcCalculatorBase
    {
        public InsetArcCalculator(double backgroundCircleThickness, double valueCircleThickness) : base(backgroundCircleThickness, valueCircleThickness)
        {

        }

        public override void Calculate(double minValue, double maxValue, double currentValue)
        {
            var maxThickness = Math.Max(_backgroundCircleThickness, _valueCircleThickness);

            BackgroundCircleRadius = new Size((ORIGIN - maxThickness) + (_backgroundCircleThickness / 2), (ORIGIN - maxThickness) + (_backgroundCircleThickness / 2));
            ValueCircleRadius = new Size((ORIGIN - maxThickness) + (_valueCircleThickness / 2), (ORIGIN - maxThickness) + (_valueCircleThickness / 2));

            BackgroundCircleStartPosition = GetPointForAngle(BackgroundCircleRadius, 0);
            BackgroundCircleEndPosition = GetPointForAngle(BackgroundCircleRadius, 360);

            ValueAngle = GetAngleForValue(minValue, maxValue, currentValue);

            ValueCircleStartPosition = GetPointForAngle(ValueCircleRadius, 0);
            ValueCircleEndPosition = GetPointForAngle(ValueCircleRadius, ValueAngle);
        }
    }
}

using System;
using System.Windows;

namespace CircularProgressbar.ArcInfoCalculator
{
    public class ArcCalculatorBase
    {
        public Point AngleToPointConverter(double radius,double angle)
        {
            angle = angle == 360 ? 359.99 : angle;
            double piang = angle * Math.PI / 180;

            double px = 50 + (Math.Sin(piang) * radius);
            double py = 50 + (-Math.Cos(piang) * radius);

            return new Point(px, py);
        }
    }
}

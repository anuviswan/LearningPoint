using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CircularProgressbar.Converters
{
    public class AngleToPointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] is Size size && values[1] is double angle)
            {
                var radius = size.Height;
                angle = angle == 360 ? 359.99 : angle;
                double piang = angle * Math.PI / 180;

                double px = 50 +(Math.Sin(piang) * radius);
                double py = 50 +(-Math.Cos(piang) * radius);

                return new Point(px, py);
            }

            return new Point(0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

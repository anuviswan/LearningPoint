using OxyPlot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TooltipOverlayBug
{
    public class ScreenPointToOffSetScreenPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ScreenPoint screenPoint)
            {
                return new ScreenPoint(screenPoint.X, screenPoint.Y + 100);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}

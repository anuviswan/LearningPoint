using MahApps.HamBurgerMenu.CaliburnMicro.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace MahApps.HamBurgerMenu.CaliburnMicro.Converters
{
    public class PageToMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<PageViewModelBase> nmItemCollection)
            {
                return nmItemCollection.Select(item => new HamburgerMenuIconItem
                {
                    Tag = item,
                    Icon = item.Icon,
                    Label = item.Title
                });
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.ComponentModel;
using System.Globalization;
using TypeConverters.Models;

namespace TypeConverters.CustomTypeConverters
{
    public class UserInfoConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string valueStr)
            {
                var splitValues = valueStr.Split(',');
                return new UserInfo { UserName = splitValues[0], Age = Convert.ToInt32(splitValues[1]) };
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

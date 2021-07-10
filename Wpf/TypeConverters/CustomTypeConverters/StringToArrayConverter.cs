using System;
using System.ComponentModel;
using System.Globalization;

namespace TypeConverters.CustomTypeConverters
{
    public class StringToArrayConverter:TypeConverter 
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string valueStr)
            {
                return valueStr.Split(',');
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}

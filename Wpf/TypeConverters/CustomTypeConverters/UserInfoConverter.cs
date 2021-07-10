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
            return sourceType == typeof(string) ? true : base.CanConvertFrom(context, sourceType);
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
       
    }
}

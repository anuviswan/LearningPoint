using System.ComponentModel;
using TypeConverters.CustomTypeConverters;

namespace TypeConverters.Models
{
    [TypeConverter(typeof(UserInfoConverter))]
    public class UserInfo
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}

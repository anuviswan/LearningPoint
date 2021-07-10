using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

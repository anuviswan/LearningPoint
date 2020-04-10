using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Automapper._9.IoC.Dynamic.ExtensionMethods
{
    public static class TypeExtensions
    {
        public static bool HasCustomAttribute<TAttribute>(this Type source) where TAttribute : Attribute
    {
        return source.GetCustomAttributes<TAttribute>().Any();
    }

    public static bool IsStringOrValueType(this Type source)
    {
        return source == typeof(string) || source.IsValueType;
    }
}
}

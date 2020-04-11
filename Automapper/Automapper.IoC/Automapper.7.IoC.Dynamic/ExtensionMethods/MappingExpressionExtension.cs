using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;

namespace Automapper._7.IoC.Dynamic.ExtensionMethods
{
    public static class IMappingExpressionExtensions
    {
        public static IMappingExpression IgnoreAllPropertiesWithIgnoreDataMemberAttribute(
            this IMappingExpression expression, Type sourceType)
        {
            foreach (var property in sourceType.GetProperties().Where(x => x.GetCustomAttributes<IgnoreDataMemberAttribute>().Any()))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }

        public static IMappingExpression IgnoreAllPropertiesWithNoDataMemberWhenTypeHasDataContractAttribute(
            this IMappingExpression expression, Type sourceType)
        {
            if (!sourceType.GetCustomAttributes<DataContractAttribute>().Any())
            {
                return expression;
            }

            foreach (var property in sourceType.GetProperties().Where(x => !x.GetCustomAttributes<DataMemberAttribute>().Any()))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
}

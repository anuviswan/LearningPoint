using AutoMapper;
using Shared.Mapper;
using Shared.TestModels.DataTypeWithCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automapper._3.IoC.ExtensionMethods;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;

namespace Automapper._3.IoC
{
    public class ValueMapper:IValueMapper
    {

        public TDestination Map<TSource,TDestination>(TSource source)
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.ConstructServicesUsing(CreateInstance);
            });
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            CreateMap(sourceType, destinationType);
            return (TDestination)Mapper.Map<TDestination>(source);
        }

        private void CreateMapInternal<TSource, TDestination>()
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            Mapper.CreateMap<TSource, TDestination>()
                .ConstructUsing((Func<ResolutionContext, TDestination>)(r => (TDestination)CreateInstance(destinationType)))
                .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }

        public void InvokeCreateMapInternal(Type sourceType,Type destinationType)
        {
            MethodInfo mi = this.GetType().GetMethod(nameof(CreateMapInternal), BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo miConstructed = mi.MakeGenericMethod(sourceType, destinationType);
            miConstructed.Invoke(this, new object[] { });
        }
        private void CreateMap(Type sourceType, Type destinationType)
        {
            InvokeCreateMapInternal(sourceType, destinationType);

            var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in sourceProperties)
            {
                if (property.PropertyType.IsStringOrValueType())
                {
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var elementType = property.PropertyType.GetGenericArguments()[0];
                    InvokeCreateMapInternal(elementType, elementType);
                    continue;
                }

                InvokeCreateMapInternal(property.PropertyType, property.PropertyType);
            }
        }

        private static object CreateInstance(Type type)
        {
            try
            {
                return Caliburn.Micro.IoC.GetInstance(type, null);
            }
            catch
            {
                return Activator.CreateInstance(type);
            }
        }
      
    }

    
}

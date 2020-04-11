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

        private void CreateMap(Type sourceType, Type destinationType)
        {
            {
                MethodInfo mi = this.GetType().GetMethod("CreateMapInternal",BindingFlags.NonPublic|BindingFlags.Instance);
                MethodInfo miConstructed = mi.MakeGenericMethod(sourceType, destinationType);
                miConstructed.Invoke(this, new object[] { });

                //Mapper.CreateMap(sourceType, destinationType)
                //                    .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType)
                //                    .IgnoreAllPropertiesWithNoDataMemberWhenTypeHasDataContractAttribute(sourceType);
            }

            var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in sourceProperties)
            {
                if (property.PropertyType.IsStringOrValueType())
                {
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    // var sourceCollection = property.GetValue(sourceInstance, null);

                    var elementType = property.PropertyType.GetGenericArguments()[0];
                    {
                        MethodInfo mi = this.GetType().GetMethod("CreateMapInternal", BindingFlags.NonPublic | BindingFlags.Instance);
                        MethodInfo miConstructed = mi.MakeGenericMethod(elementType, elementType);
                        miConstructed.Invoke(this, new object[] { });
                    }
                    continue;
                }
                {
                    MethodInfo mi = this.GetType().GetMethod("CreateMapInternal", BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo miConstructed = mi.MakeGenericMethod(property.PropertyType, property.PropertyType);
                    miConstructed.Invoke(this, new object[] { });
                }
            
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

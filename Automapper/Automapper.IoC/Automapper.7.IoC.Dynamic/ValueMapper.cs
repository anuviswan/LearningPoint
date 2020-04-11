using Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using AutoMapper.Configuration;
using AutoMapper;
using Automapper._7.IoC.Dynamic.ExtensionMethods;
using Shared.TestModels.DataTypeWithCollections;
using System.Reflection;
using System.Collections;
using Automapper._7IoC.Dynamic.ExtensionMethods;

namespace Automapper._9.IoC.Dynamic
{
    public class ValueMapper : IValueMapper
    {
        private readonly MapperConfigurationExpression _mapperConfigurationExpression = new MapperConfigurationExpression();
        private IMapper _mapper;
        private MapperConfiguration _mapperConfiguration;

        public ValueMapper()
        {
            _mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
            _mapper = _mapperConfiguration.CreateMapper();
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            CreateMap(sourceType, destinationType);
            return _mapper.Map<TSource, TDestination>(source);

        }

        private void CreateMap(Type sourceType,Type destinationType)
        {
            _mapperConfigurationExpression.ConstructServicesUsing(CreateInstance);

            _mapperConfigurationExpression.CreateMap(sourceType, destinationType)
                                          .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType)
                                          .IgnoreAllPropertiesWithNoDataMemberWhenTypeHasDataContractAttribute(sourceType)
                                          .ConstructUsingServiceLocator();
            _mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
            _mapper = new Mapper(_mapperConfiguration);

            var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var property in sourceProperties)
            {
                if (property.PropertyType.IsStringOrValueType())
                {
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                   // var sourceCollection = property.GetValue(sourceInstance, null);
                    var elementType = property.PropertyType.GetGenericArguments()[0];
                    CreateMap(elementType, elementType);
                    continue;
                }

                CreateMap(property.PropertyType, property.PropertyType);
            }
        }

        private object CreateInstance(Type type)
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

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }
    }
}

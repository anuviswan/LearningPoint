using AutoMapper;
using Models.Mapper;
using Models.TestModels.DataTypeWithCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automapper._3.IoC.ExtensionMethods;
using System.ComponentModel.Design;
namespace Automapper._3.IoC
{
    public class ValueMapper:IValueMapper
    {

        public TDestination Map<TSource,TDestination>(TSource source)
        {
            Mapper.CreateMap(typeof(TSource),typeof(TDestination)).IgnoreAllPropertiesWithIgnoreDataMemberAttribute(typeof(TSource));
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }
    }
}

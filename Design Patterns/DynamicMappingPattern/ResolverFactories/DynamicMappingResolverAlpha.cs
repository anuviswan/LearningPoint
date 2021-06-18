using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DynamicMappingPattern.ResolverFactories
{
    public class DynamicMappingResolverAlpha : DynamicMappingResolver
    {
        public override IStatergy<TProduct> ResolveFor<TProduct>(TProduct product)
        {
            var availableTypes = this.GetType().Assembly.GetTypes();
            var statergies = availableTypes.Where(x=>x.GetTypeInfo()
                                                     .ImplementedInterfaces
                                                     .Any(x => x.GetTypeInfo().IsGenericType 
                                                        && x.GetGenericTypeDefinition() == typeof(IStatergy<>)
                                                        && x.GetGenericArguments().First() == product.GetType()));

            return (dynamic) Activator.CreateInstance(statergies.First());
            
        }
    }
}

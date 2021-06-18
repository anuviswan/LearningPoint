using System;
using System.Linq;
using System.Reflection;

namespace DynamicMappingPattern.ResolverFactories
{
    // Resolution algorithm could vary. In this case, the resolution is based on the 
    // the only implementation of type in the assembly.
    // Another resolution algorithm might have to deal with multiple implementation of statergy and need to pick one
    // based on some other criteria
    public class DynamicMappingResolverAlpha : DynamicResolverFactory
    {
        
        public override IStatergy<TProduct> ResolveFor<TProduct>(TProduct product)
        {
            var availableTypes = this.GetType().Assembly.GetTypes();
            var statergies = availableTypes.Where(x=>x.GetTypeInfo()
                                                     .ImplementedInterfaces
                                                     .Any(x => x.GetTypeInfo().IsGenericType 
                                                        && x.GetGenericTypeDefinition() == typeof(IStatergy<>)
                                                        && x.GetGenericArguments().First() == product.GetType()));

            
            return (dynamic) Activator.CreateInstance(statergies.Single());
            
        }
    }
}

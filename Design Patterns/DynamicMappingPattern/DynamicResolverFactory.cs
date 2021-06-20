using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMappingPattern
{
    public interface Foo<in TProduct> where TProduct : IProduct
    {
        IStrategy<IProduct> ResolveFor(TProduct product);
    }
    public abstract class DynamicResolverFactory<TProduct> where TProduct : IProduct
    {
        public abstract IStrategy<IProduct> ResolveFor(TProduct product);

        public void DoOperation(TProduct product)
        {
            var statergy = ResolveFor(product);
            statergy.DoOperation();
        }

    }
}

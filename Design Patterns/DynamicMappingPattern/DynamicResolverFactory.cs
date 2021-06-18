using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMappingPattern
{
    public abstract class DynamicResolverFactory
    {
        public abstract IStatergy<TProduct> ResolveFor<TProduct>(TProduct product) where TProduct:IProduct;

        public void DoOperation(IProduct product)
        {
            var statergy = ResolveFor(product);
            statergy.DoOperation();
        }

    }
}

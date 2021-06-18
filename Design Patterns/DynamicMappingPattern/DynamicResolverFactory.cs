using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMappingPattern
{
    public abstract class DynamicResolverFactory<TProduct> where TProduct : IProduct
    {
        public abstract IStatergy<TProduct> ResolveFor(TProduct product);

        public void DoOperation(TProduct product)
        {
            var statergy = ResolveFor(product);
            statergy.DoOperation();
        }

    }
}

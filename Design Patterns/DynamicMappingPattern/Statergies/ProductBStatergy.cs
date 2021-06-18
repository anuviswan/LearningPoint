using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMappingPattern.Products;

namespace DynamicMappingPattern.Statergies
{
    public class ProductBStatergy : IStatergy<ProductB>
    {
        public void DoOperation() => Console.WriteLine($"Executing {nameof(ProductBStatergy)}.{nameof(DoOperation)}");
    }
}

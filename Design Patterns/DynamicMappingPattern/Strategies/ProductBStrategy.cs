using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMappingPattern.Products;

namespace DynamicMappingPattern.Strategies
{
    public class ProductBStrategy : IStrategy<ProductB>
    {
        public void DoOperation() => Console.WriteLine($"Executing {nameof(ProductBStrategy)}.{nameof(DoOperation)}");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Products
{
    public interface IProduct
    {
        void Initialilze();
        void DoOperation();
        void Shutdown();
    }
}

using FactoryMethod.Products;

namespace FactoryMethod.Factories
{
    public class ProductAlphaFactory:ProductFactoryBase
    {
        protected override IProduct GetProduct()
        {
            return new ProductAlpha();
        }
    }
}

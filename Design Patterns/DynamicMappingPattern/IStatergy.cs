namespace DynamicMappingPattern
{
    public interface IStatergy<out TProduct> where TProduct:IProduct 
    {
        void DoOperation();
    }
}

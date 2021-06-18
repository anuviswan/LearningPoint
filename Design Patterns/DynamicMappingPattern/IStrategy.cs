namespace DynamicMappingPattern
{
    public interface IStrategy<out TProduct> where TProduct:IProduct 
    {
        void DoOperation();
    }
}

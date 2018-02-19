namespace RTDemo_001.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public CategoryModel Category { get; set; }
        public int ItemsSold { get; set; }
    }
}

using RTDemo_001.Contracts;
using RTDemo_001.Models;
using System.Collections.Generic;

namespace RTDemo_001.Utils
{
    public class MockData : IDataGeneration
    {
        public IList<ProductModel> Load(string fileName = null)
        {
            var categories = new List<CategoryModel>()
            {
                new CategoryModel() { CategoryName = "Mobile" },
                new CategoryModel() { CategoryName = "Fitness Bands" },
                new CategoryModel() { CategoryName = "Headsets" }
            };
            var products = new List<ProductModel>()
            {
                new ProductModel(){ ProductName = "IPhone X", Price = 1000 , Category = categories[0] , ItemsSold = 3200 },
                new ProductModel(){ ProductName = "Google Pixel", Price = 900 , Category = categories[0], ItemsSold = 1200 },

                new ProductModel(){ ProductName = "Fitbit" , Price = 500 , Category = categories[1], ItemsSold = 6200},

                new ProductModel(){ ProductName = "V-Moda" , Price = 700 , Category = categories[2] , ItemsSold = 2300},
                new ProductModel(){ ProductName = "Sennheisser" , Price = 300 , Category = categories[2], ItemsSold = 6700},
                new ProductModel(){ ProductName = "Bose" , Price = 1200 , Category = categories[2], ItemsSold = 1600}
            };
            return products;
        }

    }
}

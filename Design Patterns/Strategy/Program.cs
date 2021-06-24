using Strategy.Read;
using Strategy.SortAlgorithms;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var productInstance = new Product<int>();
            productInstance.SortingAlgorithm = new QuickSort<int>();
            productInstance.Reader = new JsonReader<int>();
            Console.WriteLine("Product Initialized and Algorithm assigned");

            Execute(productInstance,default);

            productInstance = new Product<int>();
            productInstance.SortingAlgorithm = new BubbleSort<int>();
            productInstance.Reader = new XmlReader<int>();
            Console.WriteLine("Product Initialized and Algorithm assigned");

            Execute(productInstance, default);

            productInstance = new Product<int>();
            productInstance.SortingAlgorithm = new BucketSort<int>();
            productInstance.Reader = new CsvReader<int>();
            Console.WriteLine("Product Initialized and Algorithm assigned");

            Execute(productInstance, default);

            Console.ReadLine();
        }

        public static void Execute(IProduct<int> product,string fileName)
        {
            Console.WriteLine("Executing Client Code");
            var data = product.Read(fileName);
            var sortedData = product.Sort(data);
            product.Display(sortedData);
            Console.WriteLine("Completed Execution");
            Console.WriteLine();
        }
    }
}

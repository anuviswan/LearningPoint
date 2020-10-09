using System;

namespace BarAssembly
{
    public class Bar
    {
        public void Print<T>(T data)
        {
            Console.WriteLine($"Type : {typeof(T)}");
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} = { property.GetValue(data)}");
            }
        }
    }
}

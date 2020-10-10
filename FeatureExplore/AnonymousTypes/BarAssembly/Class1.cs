using System;
using System.Data;

namespace BarAssembly
{
    public class Bar
    {
        public void Print(object data)
        {
            var typeSchema = new { UserName = string.Empty, Age = default(int), JoiningDate = default(DateTime) };
            var castInstance = Cast(typeSchema, data);
            Console.WriteLine(data.GetType() == castInstance.GetType());
        }
        private static T Cast<T>(T typeHolder, Object x) where T : class
        {
            return (T)x;
        }
    }
}

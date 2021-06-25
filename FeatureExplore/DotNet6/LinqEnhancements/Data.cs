using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEnhancements
{
    public record User(int Id, string Name);
    public static class EnumerableExtensions
    {
        public static string ToPrintString<T>(this IEnumerable<T> source) => string.Join(",", source);
    }

    public static class Data
    {
        public static IEnumerable<User> Generate(int maxCount)
        {
            var random = new Random();
            for (int i = 0; i < maxCount; i++)
                yield return new User(i, $"User{random.Next(1, 5)}");
        }
    }
}

using System;
using System.Linq;
using System.Reflection;

namespace Records
{
    class Program
    {
        static void Main(string[] args)
        {
            var userOriginal = new User
            {
                UserName = "Anuviswan",
                Id = 1
            };

            var userModified = userOriginal with { UserName = "Jia" };
            var userRevereted = userModified with { UserName = "Anuviswan" };

            userModified.Id = 2;

            

            Console.WriteLine($"Original : {userOriginal.UserName},{userOriginal.Id}");
            Console.WriteLine($"Modified : {userModified.UserName},{userModified.Id}");

            Console.WriteLine(userOriginal == userModified);
            //Console.WriteLine(userOriginal == userRevereted);

            Console.WriteLine(userOriginal.Equals(userModified));
            //Console.WriteLine(userOriginal.Equals(userRevereted));

            Console.WriteLine(ReferenceEquals(userOriginal,userModified));
            //Console.WriteLine(ReferenceEquals(userOriginal,userRevereted));
        }

        private static bool Immutable(Type type)
        {
            if (type.IsPrimitive) return true;
            if (type == typeof(string)) return true;
            var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var isShallowImmutable = fieldInfos.All(f => f.IsInitOnly);
            if (!isShallowImmutable) return false;
            var isDeepImmutable = fieldInfos.All(f => Immutable(f.FieldType));
            return isDeepImmutable;
        }
    }
    //public record User(string UserName, int Id);

    public record User
    {
        public string UserName { get; init; }
        public int Id;
    }

    class User1
    {
        public string UserName { get; init; }
        public int Id { get; set; }
    }
}

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}
using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace UsingDeclaration
{
    class Program
    {
        static void Main(string[] args)
        {
            var example1 = new Example();
            example1.UsingStatement();
            example1.UsingDeclaration();

            Console.ReadLine();
        }

      
    }

    public class Example: IExample
    {
        public int UsingStatement()
        {
            using (var customDisposibleObject = new CustomDisposibleObject())
            {
                customDisposibleObject.Talk(nameof(IExample.UsingStatement));
                return default;
            }
        }

        public int UsingDeclaration()
        {
            using var customDisposibleObject = new CustomDisposibleObject();
            customDisposibleObject.Talk(nameof(IExample.UsingDeclaration));
            return default;
        }
    }

    


    public interface IExample
    {
        int UsingStatement();
        int UsingDeclaration();
    }

    public interface ITalk
    {
        void Talk(string message);
    }

    public class CustomDisposibleObject : IDisposable,ITalk
    {
        public void Dispose()
        {
            Console.WriteLine($"Disposing {nameof(CustomDisposibleObject)}");
        }

        public void Talk(string message)
        {
            Console.WriteLine($"{nameof(CustomDisposibleObject)}-{nameof(ITalk.Talk)} : {message}");
        }
    }
}

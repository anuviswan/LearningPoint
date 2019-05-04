using System;

namespace Composite
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("When using Composite Object");
            var directoryInstance = new DirectoryObject("BaseDirectyory");
            for(var i = 0; i < 10; i++)
            {
                directoryInstance.Add(new FileObject($"{i.ToString()}_File"));
            }

            GetSize(directoryInstance);

            Console.WriteLine("When using Component Object");
            var fileInstance = new FileObject("Another File Instance");
            GetSize(fileInstance);
            Console.ReadLine();
        }

        private static void GetSize(IMetaInfo instance)
        {
            instance.GetSize();
        }
    }
}

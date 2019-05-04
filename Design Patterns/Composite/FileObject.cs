using System;

namespace Composite
{
    public class FileObject : IMetaInfo
    {
        private string _fileName;
        public FileObject(string fileName)
        {
            _fileName = fileName;
        }
        public double GetSize()
        {
            Console.WriteLine($"Calculating size of {_fileName}");
            return 0;
        }
    }
}

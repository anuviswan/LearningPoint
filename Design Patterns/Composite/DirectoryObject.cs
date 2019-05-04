using System.Collections.Generic;

namespace Composite
{
    public class DirectoryObject : IMetaInfo
    {
        private string _directoryName;
        private List<IMetaInfo> _fileCollection;
        public DirectoryObject(string directoryName)
        {
            _directoryName = directoryName;
            _fileCollection = new List<IMetaInfo>();
        }

        public void Add(IMetaInfo file)
        {
            _fileCollection.Add(file);
        }

        public void Remove(IMetaInfo file)
        {
            _fileCollection.Remove(file);
        }
        public double GetSize()
        {
            var directorySize = 0d;
            foreach (var file in _fileCollection)
            {
                directorySize += file.GetSize();
            }
            return directorySize;
        }
    }
}

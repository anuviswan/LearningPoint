using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCode
{
    public class FileReaderAsync
    {
        public FileReaderAsync(bool throwError=false)
        {
            if (throwError)
                throw new InvalidOperationException();
        }
        public async Task<string> ReadFileAsync(string fileName)
        {
            using(var file = File.OpenText(fileName)) 
                return await file.ReadToEndAsync();
        }
    }
}

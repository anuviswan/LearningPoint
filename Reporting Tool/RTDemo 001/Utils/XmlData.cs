using RTDemo_001.Contracts;
using RTDemo_001.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RTDemo_001.Utils
{
    public class XmlData : IDataGeneration
    {
        public IList<ProductModel> Load(string fileName = null)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ProductModel>));
            var reader = new StreamReader(fileName ?? throw new ArgumentNullException(nameof(fileName)));
            reader.ReadToEnd();

            var result = (List<ProductModel>)xmlSerializer.Deserialize(reader);
            return result;

        }
    }
}

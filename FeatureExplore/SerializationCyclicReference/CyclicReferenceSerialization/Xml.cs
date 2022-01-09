using System.Runtime.Serialization;
using System.Text;

namespace CyclicReferenceSerialization;
public static class Xml
{
    public static string Serialize<T>(T item)
    {
        var serializer = new DataContractSerializer(typeof(T));
        using var output = new StringWriter();
        using var writer = new System.Xml.XmlTextWriter(output);
        
        serializer.WriteObject(writer, item);
        return output.GetStringBuilder().ToString();
    }

    public static T Deserialize<T>(string serializedData)
    {
        var serializer = new DataContractSerializer(typeof(T));
        using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedData));
        return (T)serializer.ReadObject(memoryStream);
    }
}

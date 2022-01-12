using Newtonsoft.Json;

namespace CyclicReferenceSerialization;
public class JsonSerializer:ISerializer<string>
{
    public string Serialize<T>(T item)
    {
        return JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
    }

    public T Deserialize<T>(string serializedData)
    {
        ArgumentNullException.ThrowIfNull(serializedData);

#pragma warning disable CS8603 // Possible null reference return.
        return JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
#pragma warning restore CS8603 // Possible null reference return.
    }
}
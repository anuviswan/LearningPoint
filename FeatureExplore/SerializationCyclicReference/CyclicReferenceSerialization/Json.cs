using Newtonsoft.Json;

namespace CyclicReferenceSerialization
{
    public static class Json
    {
        public static string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        public static T Deserialize<T>(string serializedData)
        {
            ArgumentNullException.ThrowIfNull(serializedData);

            return JsonConvert.DeserializeObject<T>(serializedData, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}
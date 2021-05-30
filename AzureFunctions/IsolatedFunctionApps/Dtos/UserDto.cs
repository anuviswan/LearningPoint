using System.Text.Json.Serialization;

namespace IsolatedFunctionApps.Dtos
{
    public class UserDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

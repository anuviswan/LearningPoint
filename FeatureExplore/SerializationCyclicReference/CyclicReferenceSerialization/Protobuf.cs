using ProtoBuf;
namespace CyclicReferenceSerialization;
public static class Protobuf
{
    public static byte[] Serialize<T>(T item)
    {
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, item);
        return stream.ToArray();
    }

    public static T Deserialize<T>(byte[] data)
    {
        using var stream = new MemoryStream(data);
        return Serializer.Deserialize<T>(stream);
    }
}

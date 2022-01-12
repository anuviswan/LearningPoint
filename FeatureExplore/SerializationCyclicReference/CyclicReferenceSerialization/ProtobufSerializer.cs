using ProtoBuf;
namespace CyclicReferenceSerialization;
public class ProtobufSerializer:ISerializer<byte[]>
{
    public byte[] Serialize<T>(T item)
    {
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, item);
        return stream.ToArray();
    }

    public T Deserialize<T>(byte[] data)
    {
        using var stream = new MemoryStream(data);
        return Serializer.Deserialize<T>(stream);
    }
}

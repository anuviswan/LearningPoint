namespace CyclicReferenceSerialization;
public interface ISerializer<Tout>
{
    Tout Serialize<T>(T item);
    T Deserialize<T>(Tout data);
}

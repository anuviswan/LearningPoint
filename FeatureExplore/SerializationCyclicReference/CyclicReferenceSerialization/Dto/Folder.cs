using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]
[KnownType(typeof(File))]
[KnownType(typeof(Folder))]
[ProtoContract]
public class Folder:IFileFolderBase
{
    [DataMember]
    [ProtoMember(1)]
    public string Name { get; set; }

    [DataMember]
    [ProtoMember(2)]
    public Guid Id { get; set; }

    [DataMember]
    [ProtoMember(3)]
    public Folder Parent { get; set; }

    [DataMember]
    [ProtoMember(4)]
    public IEnumerable<IFileFolderBase> Children { get; set; }
}

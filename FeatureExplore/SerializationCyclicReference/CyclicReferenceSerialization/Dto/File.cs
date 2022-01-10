using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]
[ProtoContract]
public class File : IFileFolderBase
{
    [DataMember]
    [ProtoMember(1)]
    public Guid Id { get; set; }
    
    [DataMember]
    [ProtoMember(2)]
    public string Name { get; set; }

    [DataMember]
    [ProtoMember(3)]
    public Folder Parent { get; set; }
}

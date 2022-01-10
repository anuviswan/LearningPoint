using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract]
[ProtoContract]
public class FolderSerialized
{
    [DataMember]
    [ProtoMember(1)]
    public Folder Root { get; set; }
}

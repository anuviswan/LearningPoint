using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]

[ProtoContract]
public class Folder:FileFolderBase
{

    [DataMember]
    [ProtoMember(4)]
    public IEnumerable<FileFolderBase> Children { get; set; }
}

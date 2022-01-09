using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract]
public class FolderSerialized
{
    [DataMember]
    public Folder Root { get; set; }
}

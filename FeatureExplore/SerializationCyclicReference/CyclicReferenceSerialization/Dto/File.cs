using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]
public class File : IFileFolderBase
{
    [DataMember]
    public Guid Id { get; set; }
    
    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public Folder Parent { get; set; }
}

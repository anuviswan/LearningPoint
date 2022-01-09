using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]
[KnownType(typeof(File))]
[KnownType(typeof(Folder))]
public class Folder:IFileFolderBase
{
    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public Guid Id { get; set; }

    [DataMember]
    public Folder Parent { get; set; }

    [DataMember]
    public List<IFileFolderBase> Children { get; set; }
}

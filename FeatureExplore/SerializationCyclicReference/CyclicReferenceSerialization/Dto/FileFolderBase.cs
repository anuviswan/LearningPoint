using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract(IsReference = true)]
[KnownType(typeof(File))]
[KnownType(typeof(Folder))]

[ProtoContract]
[ProtoInclude(100, typeof(Folder))]
[ProtoInclude(200, typeof(File))]
public abstract class FileFolderBase
{
    [ProtoMember(1)]
    [DataMember]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public Folder Parent { get; set; }

    // To be used for serialization
    [ProtoMember(3)]
    public Guid ParentId 
    { 
        get => Parent?.Id ?? Guid.Empty; 
        set
        {
            if(Parent is null)
            {
                Parent = new Folder();
            }
            Parent.Id = value;
        } 
    }

}
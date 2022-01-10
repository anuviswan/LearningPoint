using ProtoBuf;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CyclicReferenceSerialization.Dto;

[ProtoContract]
[ProtoInclude(100,typeof(File))]
[ProtoInclude(200,typeof(Folder))]
public interface IFileFolderBase
{
    [ProtoMember(1)]
    Guid Id { get; set; }

    [ProtoMember(2)]
    string Name { get; set; }
}
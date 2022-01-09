using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CyclicReferenceSerialization.Dto;

public interface IFileFolderBase
{
    Guid Id { get; set; }
    string Name { get; set; }
}
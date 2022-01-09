namespace CyclicReferenceSerialization.Dto;
public class File : IFileFolderBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Folder Parent { get; set; }
}

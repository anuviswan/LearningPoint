namespace CyclicReferenceSerialization.Dto;
public class Folder:IFileFolderBase
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public Folder Parent { get; set; }
    public List<IFileFolderBase> Children { get; set; }
}

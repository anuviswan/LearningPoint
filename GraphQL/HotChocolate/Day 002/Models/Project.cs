namespace GraphQLDemo.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }

    public int TimeLogId { get; set; }
    public TimeLog Log{ get; set; }
}

namespace GraphQLDemo.Models;

[GraphQLDescription("Describes a Project information")]
public class Project
{
    [GraphQLDescription("Unique Identifier of the Project")]
    public int Id { get; set; }

    [GraphQLDescription("Name of the Project")]
    public string Name { get; set; }

    [GraphQLDescription("Describes who created the project")]
    public string CreatedBy { get; set; }
}

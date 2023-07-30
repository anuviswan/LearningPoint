using GraphQLDemo.Models;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    public async Task<Project> AddProject()
}

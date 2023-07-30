using GraphQLDemo.Database;
using GraphQLDemo.Models;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,Project project)
    {
        await dbContext.AddAsync(project);
        return project;
    } 
}

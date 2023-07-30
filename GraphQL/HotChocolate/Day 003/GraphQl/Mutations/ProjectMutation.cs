using GraphQLDemo.Database;
using GraphQLDemo.Models;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    [UseMutationConvention]
    [GraphQLDescription("Add Project")]
    public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
        [ID] Guid id, string name, string createdBy )
    {
        var project = new Project
        {
            //Id = id,
            Name = name,
            CreatedBy = createdBy
        };
        var result  = await dbContext.AddAsync(project); 
        
        await dbContext.SaveChangesAsync();
        return result.Entity;
    } 
}

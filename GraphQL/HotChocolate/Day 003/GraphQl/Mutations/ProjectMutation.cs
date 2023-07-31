using GraphQLDemo.Database;
using GraphQLDemo.Models;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    [UseMutationConvention]
    [GraphQLDescription("Add Project")]
    [Error(typeof(InvalidProjectIdException))]
    [Error(typeof(InvalidProjectNameException))]
    public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
        [ID]int id, string name, string createdBy)
    {
        if (id < 0) throw new InvalidProjectIdException(id);
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidProjectNameException(name);

        var result = await dbContext.AddAsync(new Project
        {
            Id = id,
            Name = name,
            CreatedBy = createdBy
        });

        await dbContext.SaveChangesAsync();
        return result.Entity;
    }


    public async Task<Project> AddProjectType([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext, Project project)
    {
        var result = await dbContext.AddAsync(project);

        await dbContext.SaveChangesAsync();
        return result.Entity;
    }
}

using GraphQLDemo.Database;
using GraphQLDemo.Models;
using HotChocolate.Subscriptions;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    [UseMutationConvention]
    [GraphQLDescription("Add Project")]
    [Error(typeof(InvalidProjectIdException))]
    [Error(typeof(InvalidProjectNameException))]
    public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
        [Service] ITopicEventSender topicSender,
        [ID]int id, string name, string createdBy)
    {
        if (id < 0) throw new InvalidProjectIdException(id);
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidProjectNameException(name);

        var project = new Project
        {
            Id = id,
            Name = name,
            CreatedBy = createdBy
        };
        var result = await dbContext.AddAsync(project);
        await dbContext.SaveChangesAsync();

        await topicSender.SendAsync(nameof(AddProject), project);
        
        return result.Entity;
    }


    public async Task<Project> AddProjectType([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext, Project project)
    {
        var result = await dbContext.AddAsync(project);

        await dbContext.SaveChangesAsync();
        return result.Entity;
    }
}

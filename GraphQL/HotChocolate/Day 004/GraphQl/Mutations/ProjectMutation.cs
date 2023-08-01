using GraphQLDemo.Database;
using GraphQLDemo.Models;
using HotChocolate.Subscriptions;

[ExtendObjectType(typeof(Mutation))]
public class ProjectMutation
{
    [UseMutationConvention]
    [GraphQLDescription("Add Project")]
    public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
        [Service(ServiceKind.Synchronized)] ITopicEventSender topicSender,
        [ID]int id, string name, string createdBy)
    {
        var project = new Project
        {
            Id = id,
            Name = name,
            CreatedBy = createdBy
        };
        var result = await dbContext.AddAsync(project);

        await topicSender.SendAsync(nameof(AddProject), project);
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

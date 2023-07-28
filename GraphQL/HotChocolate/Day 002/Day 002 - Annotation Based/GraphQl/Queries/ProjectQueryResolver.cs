using GraphQLDemo.Database;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQl.Queries;

[ExtendObjectType(typeof(Query))]
public class ProjectQueryResolver
{
    [GraphQLDescription("Fetch all projects")]
    public IEnumerable<Project> FetchAllProjects([Service(ServiceKind.Synchronized)]DemoGraphContext dbContext)
    {
        return dbContext.Projects;
    }

    [GraphQLDescription("Fetch project by name")]
    public Project? FetchProjectByName([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,string projectName)
    {
        return dbContext.Projects.FirstOrDefault(x => string.Equals(x.Name, projectName, StringComparison.OrdinalIgnoreCase));
    }
    
}

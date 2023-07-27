using GraphQLDemo.Database;
using GraphQLDemo.Models;
using System.Data;

namespace GraphQLDemo.GraphQl.Queries;

[ExtendObjectType("Query")]
public class ProjectQueryResolver
{
    public IEnumerable<Project> FetchAllProjects([Service(ServiceKind.Synchronized)]DemoGraphContext dbContext)
    {
        return dbContext.Projects;
    }

    public Project? FetchProjectByName([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,string projectName)
    {
        return dbContext.Projects.FirstOrDefault(x => string.Equals(x.Name, projectName, StringComparison.OrdinalIgnoreCase));
    }
    
}

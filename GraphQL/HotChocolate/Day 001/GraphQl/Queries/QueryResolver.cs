using HelloWorldApi.Database;
using HelloWorldApi.Models;
using System.Data;

namespace GraphqlUsingHotChocolate.GraphQl.Queries
{
    public class QueryResolver
    {
        public IEnumerable<Project> FetchAllProjects([Service(ServiceKind.Synchronized)]TimeGraphContext dbContext)
        {
            return dbContext.Projects;
        }

        public Project? FetchProjectByName([Service(ServiceKind.Synchronized)] TimeGraphContext dbContext,string projectName)
        {
            return dbContext.Projects.FirstOrDefault(x => string.Equals(x.Name, projectName, StringComparison.OrdinalIgnoreCase));
        }
        
    }
}

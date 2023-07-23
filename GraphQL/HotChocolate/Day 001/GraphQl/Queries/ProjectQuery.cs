using HelloWorldApi.Database;
using HelloWorldApi.Models;

namespace GraphqlUsingHotChocolate.GraphQl.Queries
{
    public class ProjectQuery
    {
        public IEnumerable<Project> GetProjects([Service(ServiceKind.Synchronized)]TimeGraphContext dbContext)
        {
            return dbContext.Projects;
        }
        
    }
}

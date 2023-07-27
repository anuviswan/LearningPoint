using GraphQLDemo.Database;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQl.Queries;

[ExtendObjectType("Query")]
public class TimeLogQueryResolver
{
    public IEnumerable<TimeLog> FetchAllTimeLog([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext)
    {
        return dbContext.TimeLogs;
    }
}

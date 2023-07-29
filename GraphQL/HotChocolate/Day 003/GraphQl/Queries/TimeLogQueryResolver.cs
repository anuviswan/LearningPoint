using GraphQLDemo.Database;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQl.Queries;

[ExtendObjectType(typeof(Query))]
public class TimeLogQueryResolver
{
    [GraphQLDescription("Fetch all timelog")]
    public IEnumerable<TimeLog> FetchAllTimeLog([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext)
    {
        return dbContext.TimeLogs;
    }
}

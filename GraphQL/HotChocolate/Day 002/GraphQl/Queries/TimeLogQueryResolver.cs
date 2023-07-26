using GraphQLDemo.Database;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQl.Queries;

public class TimeLogQueryResolver
{
    public IEnumerable<TimeLog> FetchAllTimeLog([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext)
    {
        return dbContext.TimeLogs;
    }
}

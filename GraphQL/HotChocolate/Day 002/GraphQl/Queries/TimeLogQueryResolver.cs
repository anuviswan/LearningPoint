using HelloWorldApi.Database;
using HelloWorldApi.Models;

namespace GraphqlUsingHotChocolate.GraphQl.Queries;

public class TimeLogQueryResolver
{
    public IEnumerable<TimeLog> FetchAllTimeLog([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext)
    {
        return dbContext.TimeLogs;
    }
}

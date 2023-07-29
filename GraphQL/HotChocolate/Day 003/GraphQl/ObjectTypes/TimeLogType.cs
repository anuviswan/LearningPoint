using GraphQLDemo.Models;

public class TimeLogType :ObjectType<TimeLog>
{
    protected override void Configure(IObjectTypeDescriptor<TimeLog> descriptor)
    {
        descriptor.Description("Describes a Timelog information");

        descriptor.Field(x => x.Id)
            .Description("Unique Identifier");

        descriptor.Field(x => x.From)
            .Description("Start Time");

        descriptor.Field(x => x.To)
            .Description("End Time");

        descriptor.Field(x => x.User)
            .Description("User");
    }
}

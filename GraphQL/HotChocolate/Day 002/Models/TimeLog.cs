namespace GraphQLDemo.Models;

[GraphQLDescription("Describes a Timelog information")]
public class TimeLog
{
    [GraphQLDescription("Unique Identifier")]
    public int Id { get; set; }

    [GraphQLDescription("Start Time")]
    public DateTime From { get; set; }

    [GraphQLDescription("End Time")]
    public DateTime To { get; set; }

    [GraphQLDescription("User")]
    public string User { get; set; }
}

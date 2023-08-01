using GraphQLDemo.Models;

namespace Day004.GraphQl.Subscriptions;

[ExtendObjectType(typeof(Subscription))]
public class ProjectSubscription
{
    [Subscribe]
    [Topic(nameof(ProjectMutation.AddProject))]
    public Project AddedProject([EventMessage] Project project) => project;
}

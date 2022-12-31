namespace Saga.Shared.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RabbitQueueAttribute : Attribute
{
    public string Name { get; set; }
    public RabbitQueueAttribute(string name) => Name = name;
}

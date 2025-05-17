namespace AggregatoryService;

public record ServiceDiscoveryOptions
{
    public List<Service> Services { get; set; } = [];
    public string ResolverName { get; set; } = null!;
    public string ResolverPort { get; set; } = null!;
}

public record Service(string Key, string Name);

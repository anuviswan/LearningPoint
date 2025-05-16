namespace AggregatoryService;

public record ServiceDiscovery
{
    public List<string> Services { get; set; } = [];
    public string ResolverName { get; set; } = null!;
    public string ResolverPort { get; set; } = null!;
}

public class DevelopmentHttpClientFactory : IHttpClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DevelopmentHttpClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public HttpClient CreateClient(string name)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        return new HttpClient(handler);
    }
}


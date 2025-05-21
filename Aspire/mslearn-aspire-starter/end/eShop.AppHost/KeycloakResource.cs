using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;

namespace Aspire.Hosting;

internal static class KeycloakHostingExtensions
{
    private const int DefaultContainerPort = 8080;

    public static IResourceBuilder<KeycloakContainerResource> AddKeycloakContainer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? port = null,
        string? tag = null)
    {
        var keycloakContainer = new KeycloakContainerResource(name);

        var resourceBuilder = builder.AddResource(keycloakContainer)
                                     .WithAnnotation(new ContainerImageAnnotation { Registry = "quay.io", Image = "keycloak/keycloak", Tag = tag ?? "latest" })
                                     .WithHttpEndpoint(port: port, targetPort: DefaultContainerPort)
                                     .WithEnvironment("KEYCLOAK_ADMIN", "admin")
                                     .WithEnvironment("KEYCLOAK_ADMIN_PASSWORD", "admin");

        if (builder.ExecutionContext.IsRunMode)
        {
            resourceBuilder.WithArgs("start-dev");
        }
        else
        {
            resourceBuilder.WithArgs("start");
        }

        return resourceBuilder;
    }

    public static IResourceBuilder<KeycloakContainerResource> ImportRealms(this IResourceBuilder<KeycloakContainerResource> builder, string source)
    {
        builder.WithBindMount(source, "/opt/keycloak/data/import")
               .WithArgs("--import-realm");

        return builder;
    }
}

internal class KeycloakContainerResource(string name) : ContainerResource(name), IResourceWithServiceDiscovery
{
}

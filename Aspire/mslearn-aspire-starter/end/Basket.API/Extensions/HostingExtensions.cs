using eShop.Basket.API.Storage;

namespace Microsoft.Extensions.Hosting;

public static class HostingExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddDefaultAuthentication();

        builder.AddMongoDBClient("BasketDB");

        builder.Services.AddSingleton<MongoBasketStore>();

    return builder;
    }
}

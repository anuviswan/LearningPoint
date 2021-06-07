using System.Text.Json;
using IsolatedFunctionApps.Middleware;
using IsolatedFunctionApps.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IsolatedFunctionApps
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(builder=>
                {
                    builder.Services.Configure<JsonSerializerOptions>(options =>
                    {
                        options.AllowTrailingCommas = true;
                    });

                    builder.UseMiddleware<ExceptionMiddleWare>();
                })
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddSingleton<IMockDataService>(new MockDataService());
                })
                .Build();

            host.Run();
        }

    }

       
}
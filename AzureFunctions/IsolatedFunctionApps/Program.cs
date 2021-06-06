using System;
using System.Text.Json;
using System.Threading.Tasks;
using IsolatedFunctionApps.Middleware;
using IsolatedFunctionApps.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
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

        private static IFunctionsWorkerApplicationBuilder ConfigureServicesAndMiddleware(IFunctionsWorkerApplicationBuilder builder)
        {
            ConfigureJsonSerializer(builder);
            ConfigureMiddleware(builder);
            ConfigureMockDataService(builder);
            return builder;
        }

        private static void ConfigureMockDataService(IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IMockDataService>(new MockDataService());
        }

        private static IFunctionsWorkerApplicationBuilder ConfigureJsonSerializer(IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.Configure<JsonSerializerOptions>(jsonSerializerOptions =>
            {
                // override the default value
                jsonSerializerOptions.AllowTrailingCommas = true;
            });
            return builder;
        }


        private static IFunctionsWorkerApplicationBuilder ConfigureMiddleware(IFunctionsWorkerApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleWare>();
            return builder;
        }
    }

       
}
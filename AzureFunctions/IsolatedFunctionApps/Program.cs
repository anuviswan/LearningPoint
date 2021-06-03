using System.Text.Json;
using System.Threading.Tasks;
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
                .ConfigureFunctionsWorkerDefaults(c=>c.ConfigureJsonSerializer())
                .Build();

            host.Run();
        }


    }

    internal static class WorkerConfigurationExtensions
    {
        public static IFunctionsWorkerApplicationBuilder ConfigureJsonSerializer(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            });
            //builder.Services.Configure<JsonSerializerOptions>(jsonSerializerOptions =>
            //{
            //    // override the default value
            //    jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //});

            return builder;
        }

       
    }
}
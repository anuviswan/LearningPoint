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
                .ConfigureFunctionsWorkerDefaults(c=>c.ConfigureSystemTextJson())
                .Build();

            host.Run();
        }


    }

    internal static class WorkerConfigurationExtensions
    {
        /// <summary>
        /// Calling ConfigureFunctionsWorkerDefaults() configures the Functions Worker to use System.Text.Json for all JSON
        /// serialization and sets JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        /// This method uses DI to modify the JsonSerializerOptions. Call /api/HttpFunction to see the changes.
        /// </summary>
        public static IFunctionsWorkerApplicationBuilder ConfigureSystemTextJson(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.Configure<JsonSerializerOptions>(jsonSerializerOptions =>
            {
                // override the default value
                jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            return builder;
        }

       
    }
}
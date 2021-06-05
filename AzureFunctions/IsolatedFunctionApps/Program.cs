using System.Text.Json;
using System.Threading.Tasks;
using IsolatedFunctionApps.Middleware;
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
                .ConfigureFunctionsWorkerDefaults(c=>ConfigureServicesAndMiddleware(c))
                .Build();

            host.Run();
        }

        private static IFunctionsWorkerApplicationBuilder ConfigureServicesAndMiddleware(IFunctionsWorkerApplicationBuilder builder)
        {
            ConfigureJsonSerializer(builder);
            ConfigureMiddleware(builder);
            return builder;
        }

        private static IFunctionsWorkerApplicationBuilder ConfigureJsonSerializer(IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
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
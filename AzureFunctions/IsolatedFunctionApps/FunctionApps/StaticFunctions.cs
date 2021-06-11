using System.Net;
using System.Threading.Tasks;
using IsolatedFunctionApps.Dtos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IsolatedFunctionApps.FunctionApps
{
    public static class StaticFunctions
    {
        [Function(nameof(SayHello))]
        public static async Task<HttpResponseData> SayHello(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            // Use the FunctionContext.GetLogger to fetch instance of ILogger
            var logger = executionContext.GetLogger(nameof(StaticFunctions));
            logger.LogInformation("Started execution of function");

            var data = await req.ReadFromJsonAsync<UserDto>();

            // Should use HttpResponseData as response
            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteStringAsync($"Hello {data.Name}, Welcome to Isolated functions demo.");
            return response;
        }

        [Function(nameof(MultiOutputSample))]
        public static async Task<CustomOutputType> MultiOutputSample(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            // Use the FunctionContext.GetLogger to fetch instance of ILogger
            var logger = executionContext.GetLogger(nameof(StaticFunctions));
            logger.LogInformation("Started execution of function");

            var data = await req.ReadFromJsonAsync<UserDto>();

            // Should use HttpResponseData as response
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync($"Hello {data.Name}, Welcome to Isolated functions demo.");


            return new CustomOutputType
            {
                UserResponse = response,
                UserTask = $"{data.Name} have logged in"
            };
        }

    }
}

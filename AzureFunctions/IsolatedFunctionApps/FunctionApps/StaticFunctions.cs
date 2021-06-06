using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IsolatedFunctionApps.Dtos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IsolatedFunctionApps.FunctionApps
{
    public static class StaticFunctions
    {
        [Function("SayHello")]
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
    }
}

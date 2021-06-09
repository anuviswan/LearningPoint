using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using IsolatedFunctionApps.Dtos;
using IsolatedFunctionApps.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IsolatedFunctionApps.FunctionApps
{
    public class InstanceFunctions
    {
        private readonly IMockDataService _mockDataService;
        public InstanceFunctions(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        [Function(nameof(CreateUser))]
        public async Task<HttpResponseData> CreateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var queryStrings = System.Web.HttpUtility.ParseQueryString(req.Url.PathAndQuery);
            var userName = queryStrings["user"];

            // Use the FunctionContext.GetLogger to fetch instance of ILogger
            var logger = executionContext.GetLogger(nameof(StaticFunctions));
            logger.LogInformation("Started execution of function");

            var data = _mockDataService.CreateUser(userName);

            // Should use HttpResponseData as response
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync<UserDto>(data);

            return response;
        }

        [Function(nameof(InvalidOperation))]
        public Task<HttpResponseData> InvalidOperation( 
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            throw new System.Exception("Mock Exception");
        }
    }
}

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace IsolatedFunctionApps.Dtos
{
    public class CustomOutputType
    {
        [QueueOutput("SampleQueue")]
        public string UserTask { get; set; }
        public HttpResponseData UserResponse { get; set; }
    }
}

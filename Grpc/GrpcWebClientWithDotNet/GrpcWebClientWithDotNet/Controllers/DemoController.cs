using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcDemoServer;
using Microsoft.AspNetCore.Mvc;

namespace GrpcWebClientWithDotNet.Controllers
{
    [Route("/[controller]")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("SayHello")]
        public async Task<IActionResult> SayHello()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7280", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

            var client = new Greeter.GreeterClient(channel);
            var response = await client.SayHelloAsync(new HelloRequest { Name = ".NET" });
            return Ok(response.Message);
        }
    }
}

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
        [Route("GetInstrumentStatus")]
        public async Task<IActionResult> GetInstrumentStatus(int instrumentId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7280", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

            var client = new Instrument.InstrumentClient(channel);
            var response = await client.ReadStatusAsync(new ReadStatusRequest { Id = instrumentId });
            return Ok(response.Status);
        }
    }
}

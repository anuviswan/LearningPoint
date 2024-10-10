using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(ILogger<DemoController> logger) : ControllerBase
{
    [HttpGet("stream")]
    public async Task GetStream(CancellationToken cts)
    {
        // Set response headers for SSE
        HttpContext.Response.ContentType = "text/event-stream";
        HttpContext.Response.Headers.Append("Cache-Control", "no-cache");
        HttpContext.Response.Headers.Append("Connection", "keep-alive");

        while (!cts.IsCancellationRequested)
        {
            await Task.Delay(1000);
            // Construct the SSE message format
            var message = $"data: Message at {DateTime.Now}\n\n";

            // Write the message to the response body
            await HttpContext.Response.WriteAsync(message);
            await HttpContext.Response.Body.FlushAsync();

        }
      
    }

}

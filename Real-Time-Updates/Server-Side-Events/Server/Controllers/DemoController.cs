using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(ILogger<DemoController> logger) : ControllerBase
{
    public async Task GetStream()
    {
        // Set response headers for SSE
        HttpContext.Response.ContentType = "text/event-stream";
        HttpContext.Response.Headers.Append("Cache-Control", "no-cache");
        HttpContext.Response.Headers.Append("Connection", "keep-alive");

        // Stream data to the client
        for (int i = 0; i < 10; i++)
        {
            // Construct the SSE message format
            var message = $"data: Message {i} at {DateTime.Now}\n\n";

            // Write the message to the response body
            await HttpContext.Response.WriteAsync(message);
            await HttpContext.Response.Body.FlushAsync();

            // Simulate some delay (e.g., for periodic updates)
            await Task.Delay(1000);
        }
    }

}

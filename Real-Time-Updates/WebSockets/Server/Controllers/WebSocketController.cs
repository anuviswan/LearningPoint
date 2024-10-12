using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WebSocketController(IWebSocketManager webSocketManager): ControllerBase
{
    [HttpGet("ws")]
    public async Task<ActionResult> HandleSocket()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var taskId = Guid.Parse(HttpContext.Request.Query["taskId"].ToString());
            webSocketManager.AddSocket(taskId, webSocket);

            var buffer = new byte[1024 * 4];
            while (webSocket.State == WebSocketState.Open)
            {
                // Listen to messages from the client if needed
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocketManager.CloseConnection(taskId);
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                }

                // Optionally, echo messages back or handle received data here
            }
            return new EmptyResult();
        }
        else
        {
            return BadRequest();
        }
    }
}

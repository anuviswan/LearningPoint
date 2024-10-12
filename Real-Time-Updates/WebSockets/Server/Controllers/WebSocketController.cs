using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WebSocketController(IWebSocketManager webSocketManager): ControllerBase
{
    [HttpGet]
    [Route("ws")]
    public async Task<ActionResult> HandleSocket()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            // Accept the WebSocket request
            WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            webSocketManager.AddSocket(webSocket);
            await HandleWebSocketConnection(webSocket);
            return Ok();
        }
        else
        {
            return BadRequest("WebSocket connection expected.");
        }
    }

    private async Task HandleWebSocketConnection(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];  // Buffer for receiving data

        WebSocketReceiveResult result;
        do
        {
            // Receive data from the WebSocket
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                // Convert the received data to string (text message)
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine("Received: " + message);
            }

            // Check if the client sent a close request
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocketManager.CloseConnection(webSocket);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client", CancellationToken.None);
            }

        } while (!result.CloseStatus.HasValue);  // Continue until the client requests to close the connection

        // Close the WebSocket connection from the server's side when done
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
    }
}

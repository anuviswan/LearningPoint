using System.Net.WebSockets;

public interface IWebSocketManager
{
    void AddSocket(WebSocket socket);
    Task SendResponse(string message);
    Task CloseConnection(WebSocket socket);
}

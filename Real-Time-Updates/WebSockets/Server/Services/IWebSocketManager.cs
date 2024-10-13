using System.Net.WebSockets;

public interface IWebSocketManager
{
    void AddSocket(WebSocket socket);
    Task SendResponse<T>(T message);
    Task CloseConnection(WebSocket socket);
}

using System.Net.WebSockets;

public interface IWebSocketManager
{
    void AddSocket(Guid taskId, WebSocket socket);
    Task SendResponse(Guid taskId, string message);
    Task CloseConnection(Guid taskId);
}

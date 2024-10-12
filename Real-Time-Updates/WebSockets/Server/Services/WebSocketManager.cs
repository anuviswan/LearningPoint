using System.Net.WebSockets;
using System.Text;

public class WebSocketManager: IWebSocketManager
{
    private IDictionary<Guid,WebSocket> _sockets = new Dictionary<Guid, WebSocket>();
    public void AddSocket(Guid taskId, WebSocket socket)
    {
        _sockets.Add(taskId, socket);
    }

    public async Task SendResponse(Guid taskId, string message)
    {
        if (_sockets.TryGetValue(taskId, out var socket) && socket.State == WebSocketState.Open)
        { 
            var messageBytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(messageBytes, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }

    public async Task CloseConnection(Guid taskId)
    {
        if( _sockets.TryGetValue(taskId,out var socket) && socket.State == WebSocketState.Open)
        {
            _sockets.Remove(taskId);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing Connection", CancellationToken.None);
        }
    }
}

﻿using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

public class WebSocketManager: IWebSocketManager
{
    private List<WebSocket> _sockets = new List<WebSocket>();
    public void AddSocket(WebSocket socket)
    {
        _sockets.Add(socket);
    }

    public async Task SendResponse<T>(T message)
    {
        foreach(var socket in _sockets)
        {
            if(socket.State == WebSocketState.Open)
            {
                var jsonMessage = JsonSerializer.Serialize(message);
                var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
                await socket.SendAsync(messageBytes, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

    public async Task CloseConnection(WebSocket socket)
    {
        _sockets.Remove(socket);
        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing Connection", CancellationToken.None);
    }
}

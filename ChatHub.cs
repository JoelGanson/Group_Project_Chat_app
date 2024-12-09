using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Called when a client connects
    public override Task OnConnectedAsync()
    {
        var username = Context.User.Identity?.Name;
        if (!string.IsNullOrEmpty(username))
        {
            UserConnectionManager.AddConnection(username, Context.ConnectionId);
        }
        return base.OnConnectedAsync();
    }

    // Called when a client disconnects
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        UserConnectionManager.RemoveConnection(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    // Send a private message
    public async Task SendPrivateMessage(string receiverUsername, string message)
    {
        var receiverConnectionId = UserConnectionManager.GetConnectionId(receiverUsername);
        if (receiverConnectionId != null)
        {
            var senderUsername = Context.User.Identity?.Name ?? "Unknown";
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", senderUsername, message);
        }
    }
}

using System.Collections.Concurrent;

public static class UserConnectionManager
{
    private static readonly ConcurrentDictionary<string, string> _connections = new();

    public static void AddConnection(string username, string connectionId)
    {
        _connections[username] = connectionId;
    }

    public static void RemoveConnection(string connectionId)
    {
        var item = _connections.FirstOrDefault(x => x.Value == connectionId);
        if (item.Key != null)
        {
            _connections.TryRemove(item.Key, out _);
        }
    }

    public static string? GetConnectionId(string username)
    {
        _connections.TryGetValue(username, out var connectionId);
        return connectionId;
    }
}

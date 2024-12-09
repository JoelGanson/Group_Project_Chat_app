public class Message
{
    public int Id { get; set; }
    public int? SenderId { get; set; }
    public int? ReceiverId { get; set; } // Null for global messages.
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}
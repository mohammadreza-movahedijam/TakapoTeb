namespace Application.Queries.Chat;

public sealed record ChatGroupViewModel
{
    public Guid Id { get; set; }
    public string? CreateAt { get; set; }
    public string? ConnectionId { get; set; }
    public string? IPAddress { get; set; }
    public int CountMessage {  get; set; }
}

namespace Application.Commands.Chat;

public sealed record ChatGroupDto
{
    public string? ConnectionId { get; set; }
    public string? IPAddress { get; set; }
}

using Domain.Types;

namespace Application.Commands.Chat;

public sealed record MessageDto
{
    public string? ConnectionId { get; set; }
    public string? IPAddress { get; set; }
    public string? ChatGroupId { get; set; }
    public string? Message { get; set; }
    public UserType UserType { get; set; }
}

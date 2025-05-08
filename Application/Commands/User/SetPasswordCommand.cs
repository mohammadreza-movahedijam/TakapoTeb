using MediatR;

namespace Application.Commands.User;

public sealed record SetPasswordCommand : IRequest
{
    public Guid UserId { get; set; }
    public string? Password { get; set; }
}

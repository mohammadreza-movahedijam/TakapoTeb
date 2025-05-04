using Application.Commands.User.DataTransferObject;
using MediatR;

namespace Application.Commands.User;

public sealed record InsertUserCommand : IRequest
{
    public UserDto User { get; set; }
    public InsertUserCommand(UserDto User)
    {
        this.User = User;
    }
}

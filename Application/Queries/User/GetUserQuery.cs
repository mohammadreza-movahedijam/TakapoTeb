using Application.Commands.User.DataTransferObject;
using MediatR;

namespace Application.Queries.User;
public sealed record GetUserQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
    public GetUserQuery(in Guid Id)
    {
        this.Id = Id;
    }
}

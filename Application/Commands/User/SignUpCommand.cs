using Application.Commands.User.DataTransferObject;
using Application.Common;
using MediatR;

namespace Application.Commands.User;

public sealed record SignUpCommand : IRequest<BaseResult>
{
    public SignUpDto? SignUp { get; set; }
}

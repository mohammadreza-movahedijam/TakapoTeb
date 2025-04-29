using Application.Commands.Role.DataTransferObject;
using MediatR;

namespace Application.Commands.Role;

public sealed record InsertRoleCommand : IRequest
{
    public RoleDto Role { get; set; }
    public InsertRoleCommand(RoleDto Role)
    {
        this.Role = Role;
    }
}

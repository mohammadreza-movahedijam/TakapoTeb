using Application.Commands.Role.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role;

public sealed record UpdateRoleCommand:IRequest
{
    public RoleDto Role { get; set; }
    public UpdateRoleCommand(RoleDto Role)
    {
        this.Role = Role;   
    }
}

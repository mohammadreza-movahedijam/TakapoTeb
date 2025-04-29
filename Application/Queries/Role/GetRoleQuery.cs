using Application.Commands.Role.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

public sealed record GetRoleQuery:IRequest<RoleDto>
{
    public Guid Id { get; set; }
    public GetRoleQuery(in Guid Id)
    {
        this.Id= Id;
    }
}

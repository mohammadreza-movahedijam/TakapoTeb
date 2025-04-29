using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role;

public sealed record DeleteRoleCommand:IRequest
{
    public Guid Id { get; set; }
    public DeleteRoleCommand(in Guid Id)
    {
        this.Id = Id;
    }
}

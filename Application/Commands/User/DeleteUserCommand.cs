using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User;

public sealed record DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteUserCommand(in Guid Id)
    {
        this.Id = Id;
    }
}

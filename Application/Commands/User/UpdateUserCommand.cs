using Application.Commands.User.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User;

public sealed record UpdateUserCommand:IRequest
{
    public UserDto User { get; set; }
    public UpdateUserCommand(UserDto User)
    {
        this.User = User;   
    }
}

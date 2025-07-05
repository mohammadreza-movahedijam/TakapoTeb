using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Message;

public sealed record DeleteMessageCommand:IRequest
{
    public Guid Id { get; set; }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Event;

public sealed record DeleteEventCommand:IRequest
{
    public Guid Id { get; set; }
}

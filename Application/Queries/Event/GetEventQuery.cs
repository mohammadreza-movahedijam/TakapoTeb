using Application.Commands.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Event;

public sealed record GetEventQuery:IRequest<EventDto>
{
    public Guid Id { get; set; }
}

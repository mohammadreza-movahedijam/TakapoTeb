using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Event;

public sealed record GetEventsQuery:
    IRequest<PaginatedList<EventViewModel>>
{
    public IPagination? Pagination { get; set; }
}

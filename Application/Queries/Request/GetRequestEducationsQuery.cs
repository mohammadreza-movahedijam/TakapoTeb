using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Request;

public sealed record GetRequestEducationsQuery
      : IRequest<PaginatedList<RequestViewModel>>
{
    public IPagination? Pagination { get; set; }

}

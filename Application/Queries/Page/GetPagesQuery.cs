using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

public sealed record GetPagesQuery:IRequest<PaginatedList<PageViewModel>>
{
    public IPagination Pagination { get; set; }
}

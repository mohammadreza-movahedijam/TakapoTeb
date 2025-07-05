using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

public sealed record GetNewsQuery:IRequest<PaginatedList<NewsViewModel>>
{
    public IPagination Pagination { get; set; }
}

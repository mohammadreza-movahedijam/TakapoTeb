using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Search;

public sealed record GetListWithKeywordQuery:
    IRequest<IReadOnlyList<SearchViewModel>>
{
    public string? Search {  get; set; }
}

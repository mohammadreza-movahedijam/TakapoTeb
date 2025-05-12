using Application.Common;
using Application.Contract;
using Application.Queries.Option;
using MediatR;

namespace Application.Queries.Option;

public sealed record GetOptionsQuery:
   IRequest<PaginatedList<OptionViewModel>>
{
    public Guid ProductId { get; set; }
    public IPagination Pagination { get; set; }
    public GetOptionsQuery(in Guid ProductId, IPagination Pagination)
    {
        this.Pagination = Pagination;
        this.ProductId = ProductId;
    }

}

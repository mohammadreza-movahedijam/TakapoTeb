using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Product;

public sealed record GetProductsQuery :
    IRequest<PaginatedList<ProductViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetProductsQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}

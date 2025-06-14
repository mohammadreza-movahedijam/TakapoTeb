using Application.Common;
using Application.Contract;
using Application.Queries.Product.ViewModels;
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

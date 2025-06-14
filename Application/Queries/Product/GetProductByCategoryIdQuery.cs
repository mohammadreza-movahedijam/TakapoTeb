using Application.Common;
using Application.Contract;
using Application.Queries.Product.ViewModels;
using MediatR;

namespace Application.Queries.Product;

public sealed record GetProductByCategoryIdQuery : 
    IRequest<PaginatedList<ProductViewModel>>
{
    public IPagination Pagination { get; set; } 
    public List<Guid>? CategoryIds { get; set; }
}

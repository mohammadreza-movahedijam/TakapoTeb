using Application.Queries.Product.ViewModels;
using MediatR;

namespace Application.Queries.Product;

public sealed record GetRelatesQuery :
    IRequest<IReadOnlyList<ProductViewModel>>
{
    public Guid ProductId { get; set; }
}

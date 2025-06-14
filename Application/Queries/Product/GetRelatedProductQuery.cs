using Application.Queries.Product.ViewModels;
using MediatR;

namespace Application.Queries.Product;

public sealed record GetRelatedProductQuery :
    IRequest<IReadOnlyList<RelatedProductViewModel>>
{
    public Guid Id { get; set; }
}

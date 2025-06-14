using MediatR;
using Application.Queries.Product.ViewModels;
namespace Application.Queries.Product;

public sealed record GetProductDetailQuery : 
    IRequest<ProductDetailViewModel>
{
    public Guid Id { get; set; }
}

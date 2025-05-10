using MediatR;

namespace Application.Commands.Product;
public sealed record InsertProductCommand : IRequest
{
    public ProductDto Product { get; set; }
    public InsertProductCommand(ProductDto Product)
    {
        this.Product = Product;
    }
}

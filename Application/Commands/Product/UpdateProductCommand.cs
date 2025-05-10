using MediatR;

namespace Application.Commands.Product;

public sealed record UpdateProductCommand : IRequest
{
    public ProductDto Product { get; set; }
    public UpdateProductCommand(ProductDto Product)
    {
        this.Product = Product;
    }
}

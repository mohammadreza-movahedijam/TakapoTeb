using MediatR;

namespace Application.Commands.ProductOption;

public sealed record UpdateProductOptionCommand : IRequest
{
    public ProductOptionDto ProductOption { get; set; }
    public UpdateProductOptionCommand(ProductOptionDto ProductOption)
    {
        this.ProductOption = ProductOption;
    }
}

using MediatR;

namespace Application.Commands.ProductOption;

public sealed record InsertProductOptionCommand : IRequest
{
    public ProductOptionDto ProductOption { get; set; }
    public InsertProductOptionCommand(ProductOptionDto ProductOption)
    {
        this.ProductOption = ProductOption;
    }
}

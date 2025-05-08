using MediatR;

namespace Application.Commands.ProductCategory;

public sealed record UpdateProductCategoryCommand : IRequest
{
    public ProductCategoryDto ProductCategory { get; set; }
    public UpdateProductCategoryCommand(ProductCategoryDto ProductCategory)
    {
        this.ProductCategory = ProductCategory;
    }
}

using Application.Queries.ProductCategory.ViewModels;
using MediatR;

namespace Application.Queries.ProductCategory;

public sealed record GetSubCategoriesQuery : 
    IRequest<IReadOnlyList<CategoryDetailViewModel>>
{
    public Guid ParentId { get; set; }
    public GetSubCategoriesQuery(in Guid ParentId)
    {
        this.ParentId = ParentId;
    }
}

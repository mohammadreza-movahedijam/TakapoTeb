using Application.Queries.ProductCategory.ViewModels;
using MediatR;

namespace Application.Queries.ProductCategory;
public sealed record GetCategoryMenuQuery :
    IRequest<IReadOnlyList<CategoryMenuViewModel>>
{
}

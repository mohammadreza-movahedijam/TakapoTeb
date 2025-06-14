using Application.Contract;
using Application.Queries.ProductCategory.ViewModels;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetCategoryMenuHandler :
    IRequestHandler<GetCategoryMenuQuery, IReadOnlyList<CategoryMenuViewModel>>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetCategoryMenuHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<CategoryMenuViewModel>> Handle
        (GetCategoryMenuQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.SubCategories);
        List<CategoryEntity> categories = await query.ToListAsync();
        return categories.Adapt<IReadOnlyList<CategoryMenuViewModel>>();
    }
}

using Application.Contract;
using Application.Queries.ProductCategory.ViewModels;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetSubCategoriesHandler :
    IRequestHandler<GetSubCategoriesQuery, IReadOnlyList<CategoryDetailViewModel>>
{


    readonly IRepository<CategoryEntity> _repository;
    public GetSubCategoriesHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<CategoryDetailViewModel>>
        Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        query = query.Where(w=>w.ParentProductCategoryId==request.ParentId).Include(i => i.SubCategories);
        List<CategoryEntity> categories = await query.ToListAsync();
        return categories.Adapt<IReadOnlyList<CategoryDetailViewModel>>();
    }
}

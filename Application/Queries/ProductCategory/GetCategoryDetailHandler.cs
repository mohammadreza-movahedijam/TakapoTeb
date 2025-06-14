using Application.Contract;
using Application.Queries.ProductCategory.ViewModels;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetCategoryDetailHandler :
    IRequestHandler<GetCategoryDetailQuery, CategoryDetailViewModel>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetCategoryDetailHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<CategoryDetailViewModel> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
    {
       
        IQueryable<CategoryEntity> query = _repository.GetByQuery();
        query = query.Where(w => w.Id == request.Id).Include(i => i.SubCategories);
        CategoryEntity? category = await query.FirstOrDefaultAsync();
        return category.Adapt<CategoryDetailViewModel>();
    }
}

using Application.Common;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetProductCategoryItemHandler :
    IRequestHandler<GetProductCategoryItemQuery, IReadOnlyList<ItemGeneric<Guid, string>>>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetProductCategoryItemHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        Handle(GetProductCategoryItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CategoryEntity> query = _repository.GetByQuery();

        
        if (!string.IsNullOrEmpty(request.Search))
        {
            query = query.Where(w => w.TitleFa!.Contains(request.Search) ||
            w.TitleEn!.Contains(request.Search));
        }
        else
        {
            query = query.Where(w => w.ParentProductCategoryId == null);
        }


        return await query.Select(s => new ItemGeneric<Guid, string>
        {
            Id = s.Id,
            Title = s.TitleFa + "-" + s.TitleEn
        }).ToListAsync(cancellationToken);
    }
}

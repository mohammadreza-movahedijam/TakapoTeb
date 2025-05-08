using Application.Common;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProductCategory;

internal sealed class GetProductCategoryItemHandler :
    IRequestHandler<GetProductCategoryItemQuery, IReadOnlyList<ItemGeneric<Guid, string>>>
{
    readonly IRepository<ProductCategoryEntity> _repository;
    public GetProductCategoryItemHandler(IRepository<ProductCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        Handle(GetProductCategoryItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProductCategoryEntity> query = _repository.GetByQuery();
        return await query
            .Where(w=>w.ParentProductCategoryId==null)
            .Select(s => new ItemGeneric<Guid, string>
        {
            Id = s.Id,
            Title = s.TitleFa + "-" + s.TitleEn
        }).ToListAsync(cancellationToken);
    }
}

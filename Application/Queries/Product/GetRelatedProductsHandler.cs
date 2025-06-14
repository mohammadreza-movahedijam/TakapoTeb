using Application.Contract;
using Application.Queries.Product.ViewModels;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Product;

internal sealed class GetRelatedProductsHandler :
    IRequestHandler<GetRelatedProductsQuery,
        IReadOnlyList<RelatedProductViewModel>>
{
    readonly IRepository<ProductEntity> _productRepository;
    public GetRelatedProductsHandler(IRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IReadOnlyList<RelatedProductViewModel>> Handle
        (GetRelatedProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProductEntity> query = _productRepository.GetByQuery();
        if (request.ProductId == Guid.Empty)
        {
            query = query.Where(w => w.Id != request.ProductId);
        }
        return await query.AsNoTracking().Where(w =>
        w.TitleEn!.Contains(request.ProductName!) || w.TitleFa!.Contains(request.ProductName!))
            .Select(s => new RelatedProductViewModel()
            {
                TitleEn = s.TitleEn,
                Id = s.Id,
                Title = s.TitleFa
            })
            .ToListAsync();
    }
}

using Application.Contract;
using Application.Queries.Product.ViewModels;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Product;

internal sealed class GetRelatesHandler :
    IRequestHandler<GetRelatesQuery, IReadOnlyList<ProductViewModel>>
{

    readonly IRepository<ProductEntity> _productRepository;
    readonly IRepository<RelatedEntity> _relatedRepository;

    public GetRelatesHandler
        (
        IRepository<ProductEntity> productRepository,
        IRepository<RelatedEntity> relatedRepository
        )
    {
        _productRepository = productRepository; 
        _relatedRepository = relatedRepository;
    }
    public async Task<IReadOnlyList<ProductViewModel>>
        Handle(GetRelatesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<ProductViewModel> list = [];
        IQueryable<RelatedEntity> query = _relatedRepository.GetByQuery();
        List<Guid>? relateds = await query.AsNoTracking()
            .Where(w => w.ProductId == request.ProductId)
            .Select(s => s.RelatedId).ToListAsync();
        if (relateds != null && relateds.Any())
        {
            IQueryable<ProductEntity> productQuery = _productRepository.GetByQuery();
            list = await productQuery.Where(w => relateds.Contains(w.Id))
                .Select(s => new ProductViewModel()
                {
                    Id = s.Id,
                    Title = s.TitleFa,
                    TitleEn = s.TitleEn,
                    ImagePath = s.ImagePath,
                }).ToListAsync();
        }
        return list;
    }
}

using Application.Contract;
using Application.Queries.Product.ViewModels;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Product;

internal sealed class GetRelatedProductHandler :
    IRequestHandler<GetRelatedProductQuery,
        IReadOnlyList<RelatedProductViewModel>>
{
    readonly IRepository<ProductEntity> _productRepository;
    readonly IRepository<RelatedEntity> _relatedRepository;
    public GetRelatedProductHandler
        (
        IRepository<ProductEntity> productRepository,
        IRepository<RelatedEntity> relatedRepository
        )
    {
        _productRepository = productRepository;
        _relatedRepository = relatedRepository;
    }



    public async Task<IReadOnlyList<RelatedProductViewModel>> Handle
        (GetRelatedProductQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<RelatedProductViewModel> list = [];
        IQueryable<RelatedEntity> query = _relatedRepository.GetByQuery();
        List<Guid>? relateds=await query.AsNoTracking()
            .Where(w=>w.ProductId==request.Id)
            .Select(s=>s.RelatedId).ToListAsync(); 
        if(relateds!=null && relateds.Any())
        {
            IQueryable<ProductEntity> productQuery =  _productRepository.GetByQuery();
            list=await productQuery.Where(w=>relateds.Contains(w.Id))
                .Select(s=>new RelatedProductViewModel()
                {
                    Id = s.Id,
                    Title=s.TitleFa,
                }).ToListAsync();
        }
        return list;
    }
}

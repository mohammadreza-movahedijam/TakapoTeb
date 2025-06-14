using Application.Contract;
using Application.Queries.Product.ViewModels;
using Domain.Entities.Product;
using MediatR;

namespace Application.Queries.Product;

internal sealed class GetProductDetailHandler :
    IRequestHandler<GetProductDetailQuery, ProductDetailViewModel>
{
    readonly IRepository<ProductEntity> _productRepository;
    public GetProductDetailHandler(IRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductDetailViewModel> Handle(GetProductDetailQuery request,
        CancellationToken cancellationToken)
    {
        ProductDetailViewModel productDetail = await _productRepository
            .GetAsync<ProductDetailViewModel>(g=>g.Id==request.Id,null,cancellationToken);
        return productDetail;
    }
}

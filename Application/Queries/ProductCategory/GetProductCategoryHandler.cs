using Application.Commands.ProductCategory;
using Application.Common.CustomException;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Queries.ProductCategory;

internal sealed class GetProductCategoryHandler :
    IRequestHandler<GetProductCategoryQuery, ProductCategoryDto>
{
    readonly IRepository<CategoryEntity> _repository;
    public GetProductCategoryHandler(IRepository<CategoryEntity>
        repository)
    {
        _repository = repository;
    }
    public async Task<ProductCategoryDto> Handle
        (GetProductCategoryQuery request, CancellationToken cancellationToken)
    {
        ProductCategoryDto ProductCategory =
            await _repository.GetAsync<ProductCategoryDto>
            (g => g.Id == request.Id, null, cancellationToken);
        if (ProductCategory == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return ProductCategory;
    }
}

using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.ProductCategory;

internal sealed class InsertProductCategoryHandler :
    IRequestHandler<InsertProductCategoryCommand>
{
    readonly IRepository<ProductCategoryEntity> _repository;
    public InsertProductCategoryHandler
        (IRepository<ProductCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertProductCategoryCommand
        request, CancellationToken cancellationToken)
    {
        ProductCategoryEntity productCategory =
            request.ProductCategory.Adapt<ProductCategoryEntity>();
   
            productCategory.ImagePath = request.ProductCategory!.ImageFile!.
                UploadImage("ProductCategory");
        
        await _repository.InsertAsync(productCategory, cancellationToken);
    }
}

using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.ProductCategory;

internal sealed class InsertProductCategoryHandler :
    IRequestHandler<InsertProductCategoryCommand>
{
    readonly IRepository<CategoryEntity> _repository;
    public InsertProductCategoryHandler
        (IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertProductCategoryCommand
        request, CancellationToken cancellationToken)
    {
        CategoryEntity productCategory =
            request.ProductCategory.Adapt<CategoryEntity>();
   
            productCategory.ImagePath = request.ProductCategory!.ImageFile!.
                UploadImage("ProductCategory");
        
        await _repository.InsertAsync(productCategory, cancellationToken);
    }
}

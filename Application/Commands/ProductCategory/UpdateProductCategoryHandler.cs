using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.ProductCategory;

internal sealed class UpdateProductCategoryHandler :
    IRequestHandler<UpdateProductCategoryCommand>
{
    readonly IRepository<CategoryEntity> _repository;
    public UpdateProductCategoryHandler(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateProductCategoryCommand request,
        CancellationToken cancellationToken)
    {
        CategoryEntity? productCategory=
            await _repository.GetAsync(g=>g.Id==request.ProductCategory.Id,cancellationToken);
        if (productCategory == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.ProductCategory.Adapt(productCategory);
        if (request.ProductCategory.ImageFile != null)
        {
           productCategory.ImagePath = request.ProductCategory!.ImageFile!.
                UploadImage("ProductCategory");
           request.ProductCategory!.ImagePath!.RemoveImage("ProductCategory");
        }
        await _repository.UpdateAsync(productCategory, cancellationToken);
    }
}

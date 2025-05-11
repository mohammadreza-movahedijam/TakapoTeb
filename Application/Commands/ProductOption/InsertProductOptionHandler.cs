using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.ProductOption;

internal sealed class InsertProductOptionHandler :
    IRequestHandler<InsertProductOptionCommand>
{
    readonly IRepository<ProductOptionEntity> _repository;
    public InsertProductOptionHandler(IRepository<ProductOptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertProductOptionCommand request, CancellationToken cancellationToken)
    {
        ProductOptionEntity productOptionEntity = request.ProductOption.Adapt<ProductOptionEntity>();
        productOptionEntity.ImagePath = request.ProductOption!.ImageFile!.UploadImage("Product");
        await _repository.InsertAsync(productOptionEntity, cancellationToken);
    }
}

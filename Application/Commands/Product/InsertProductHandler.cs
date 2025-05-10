using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.Product;

internal sealed class InsertProductHandler : IRequestHandler<InsertProductCommand>
{
    readonly IRepository<ProductEntity> _repository;
    public InsertProductHandler(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        ProductEntity product = request.Product.Adapt<ProductEntity>();
        product.ImagePath = request.Product.ImageFile!.UploadImage("Product");
        await _repository.InsertAsync(product,cancellationToken);
    }
}

using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;

namespace Application.Commands.Option;

internal sealed class InsertOptionHandler :
    IRequestHandler<InsertOptionCommand>
{
    readonly IRepository<OptionEntity> _repository;
    public InsertOptionHandler(IRepository<OptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertOptionCommand request, CancellationToken cancellationToken)
    {
        OptionEntity productOptionEntity = request.ProductOption.Adapt<OptionEntity>();
        productOptionEntity.ImagePath = request.ProductOption!.ImageFile!.UploadImage("Product");
        await _repository.InsertAsync(productOptionEntity, cancellationToken);
    }
}

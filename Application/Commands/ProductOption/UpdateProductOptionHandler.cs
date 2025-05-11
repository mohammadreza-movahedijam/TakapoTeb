using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductOption;

internal sealed class UpdateProductOptionHandler :
    IRequestHandler<UpdateProductOptionCommand>
{
    readonly IRepository<ProductOptionEntity> _repository;
    public UpdateProductOptionHandler(IRepository<ProductOptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
    {
        ProductOptionEntity? productOptionEntity =
          await _repository.GetAsync(g => g.Id == request.Id, cancellationToken);


        if (productOptionEntity == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        request.ProductOption.Adapt(productOptionEntity);
        if(request.ProductOption.ImageFile is not null)
        {
            productOptionEntity.ImagePath = request.ProductOption.ImageFile.UploadImage("Product");
            request.ProductOption.ImagePath!.RemoveImage("Product");
        }
        await _repository.UpdateAsync(productOptionEntity,cancellationToken);
    }
}

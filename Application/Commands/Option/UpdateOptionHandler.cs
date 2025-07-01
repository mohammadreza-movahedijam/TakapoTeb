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

namespace Application.Commands.Option;

internal sealed class UpdateProductOptionHandler :
    IRequestHandler<UpdateOptionCommand>
{
    readonly IRepository<OptionEntity> _repository;
    public UpdateProductOptionHandler(IRepository<OptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
    {
        OptionEntity? productOptionEntity =
          await _repository.GetAsync(g => g.Id == request.ProductOption.Id, cancellationToken);
        if (productOptionEntity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
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

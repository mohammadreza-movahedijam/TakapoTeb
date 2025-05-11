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

internal sealed class DeleteProductOptionHandler :
    IRequestHandler<DeleteProductOptionCommand>
{
    readonly IRepository<ProductOptionEntity> _repository;
    public DeleteProductOptionHandler(IRepository<ProductOptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteProductOptionCommand request, CancellationToken cancellationToken)
    {
        ProductOptionEntity? productOptionEntity =
          await _repository.GetAsync(g=>g.Id==request.Id, cancellationToken);

        if (productOptionEntity == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        productOptionEntity.IsDeleted = true;
         await _repository.UpdateAsync(productOptionEntity, cancellationToken);
    }
}

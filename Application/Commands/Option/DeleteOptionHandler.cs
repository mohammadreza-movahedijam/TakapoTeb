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

internal sealed class DeleteOptionHandler :
    IRequestHandler<DeleteOptionCommand>
{
    readonly IRepository<OptionEntity> _repository;
    public DeleteOptionHandler(IRepository<OptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
    {
        OptionEntity? productOptionEntity =
          await _repository.GetAsync(g=>g.Id==request.Id, cancellationToken);

        if (productOptionEntity == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        productOptionEntity.IsDeleted = true;
         await _repository.UpdateAsync(productOptionEntity, cancellationToken);
    }
}

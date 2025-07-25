using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Catalog;

internal sealed class DeleteCatalogHandler :
    IRequestHandler<DeleteCatalogCommand>
{
    readonly IRepository<CatalogEntity> _repository;
    public DeleteCatalogHandler(IRepository<CatalogEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteCatalogCommand request,
        CancellationToken cancellationToken)
    {
        CatalogEntity? entity = await _repository.GetAsync
           (g => g.Id == request!.Id, cancellationToken);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDeleted = true;
        await _repository.UpdateAsync (entity, cancellationToken);
    }
}

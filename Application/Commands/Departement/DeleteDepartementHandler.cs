using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Departement;

internal sealed class DeleteDepartementHandler :
    IRequestHandler<DeleteDepartementCommand>
{
    readonly IRepository<DepartementEntity> _repository;
    public DeleteDepartementHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteDepartementCommand request, CancellationToken cancellationToken)
    {
        DepartementEntity? departement = await _repository.
           GetAsync(g => g.Id == request!.Id, cancellationToken);
        if (departement == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
       departement.IsDeleted = true;
        await _repository.UpdateAsync(departement, cancellationToken);
    }
}

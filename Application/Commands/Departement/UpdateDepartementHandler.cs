using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Departement;

internal sealed class UpdateDepartementHandler : IRequestHandler<UpdateDepartementCommand>
{
    readonly IRepository<DepartementEntity> _repository;
    public UpdateDepartementHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateDepartementCommand request, 
        CancellationToken cancellationToken)
    {
        DepartementEntity? departement=await _repository.
            GetAsync(g=>g.Id==request.Departement!.Id, cancellationToken);
        if (departement == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
            }
        request.Departement.Adapt(departement);
        await _repository.UpdateAsync(departement,cancellationToken);
    }
}

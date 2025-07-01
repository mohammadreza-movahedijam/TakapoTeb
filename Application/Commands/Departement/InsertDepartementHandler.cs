using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Departement;

internal sealed class InsertDepartementHandler :
    IRequestHandler<InsertDepartementCommand>
{
    readonly IRepository<DepartementEntity> _repository;
    public InsertDepartementHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertDepartementCommand request, CancellationToken cancellationToken)
    {
        DepartementEntity departement = request.Departement.Adapt<DepartementEntity>();
        await _repository.InsertAsync(departement, cancellationToken);
    }
}

using Application.Commands.Departement;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Departement;

internal sealed class GetDepartementHandler :
    IRequestHandler<GetDepartementQuery, DepartementDto>
{
    readonly IRepository<DepartementEntity> _repository;
    public GetDepartementHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task<DepartementDto> Handle(GetDepartementQuery request,
        CancellationToken cancellationToken)
    {
        DepartementDto departement=await _repository.
            GetAsync<DepartementDto>(g=>g.Id==request.Id,null,cancellationToken);
        if(departement is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return departement;
    }
}

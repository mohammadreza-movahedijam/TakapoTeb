using Application.Commands.TreatmentCenter;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TreatmentCenter;

internal sealed class GetTreatmentCenterHandler :
    IRequestHandler<GetTreatmentCenterQuery, TreatmentCenterDto>
{
    readonly IRepository<TreatmentCenterEntity> _repository;
    public GetTreatmentCenterHandler
        (IRepository<TreatmentCenterEntity> repository)
    {
        _repository = repository;
    }
    public async Task<TreatmentCenterDto> Handle
        (GetTreatmentCenterQuery request, CancellationToken cancellationToken)
    {
        TreatmentCenterDto? TreatmentCenter=await _repository
            .GetAsync<TreatmentCenterDto>
            (g=>g.Id == request.Id,null,cancellationToken);
        if(TreatmentCenter is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return TreatmentCenter;
    }
}

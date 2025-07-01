using Application.Commands.Partner;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Partner;

internal sealed class GetPartnerHandler :
    IRequestHandler<GetPartnerQuery, PartnerDto>
{

    readonly IRepository<PartnerEntity> _partnerRepository;
    public GetPartnerHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }
    public async Task<PartnerDto> Handle(GetPartnerQuery request,
        CancellationToken cancellationToken)
    {
       PartnerDto partner=await _partnerRepository
            .GetAsync<PartnerDto>(g=>g.Id == request.Id,
            null,cancellationToken);
        if(partner==null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return partner;
    }
}

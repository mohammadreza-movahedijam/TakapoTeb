using Application.Commands.Partner;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Partner;

internal sealed class GetPartnerDetailHandler :
    IRequestHandler<GetPartnerDetailQuery, PartnerDetailViewModel>
{
    readonly IRepository<PartnerEntity>_partnerRepository;
    public GetPartnerDetailHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository  = partnerRepository;
    }
    public async Task<PartnerDetailViewModel> Handle(GetPartnerDetailQuery request, CancellationToken cancellationToken)
    {
        PartnerDetailViewModel partner = await _partnerRepository
            .GetAsync<PartnerDetailViewModel>(g => g.Id == request.Id,
            null, cancellationToken);
        if (partner == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return partner;
    }
}

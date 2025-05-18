using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Partner;

internal sealed class GetPartnersHandler :
    IRequestHandler<GetPartnersQuery, PaginatedList<PartnerViewModel>>
{
    readonly IRepository<PartnerEntity> _partnerRepository;
    public GetPartnersHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }
    public async Task<PaginatedList<PartnerViewModel>>
        Handle(GetPartnersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PartnerEntity> query = _partnerRepository.GetByQuery();
        int count = query.Count().PageCount(request!.Pagination!.pageSize);
        int total = query.Count();
        PaginatedList<PartnerViewModel> model =
            await query.MappingedAsync<PartnerEntity, PartnerViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

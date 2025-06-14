using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Partner;

internal sealed class GetPartnersWithOutPaginationHandler :
    IRequestHandler<GetPartnersWithOutPaginationQuery, IReadOnlyList<PartnerViewModel>>
{
    readonly IRepository<PartnerEntity> _repository;
    public GetPartnersWithOutPaginationHandler(IRepository<PartnerEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<PartnerViewModel>> 
        Handle(GetPartnersWithOutPaginationQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PartnerEntity> query = _repository.GetByQuery();
        return await query.Select(s => new PartnerViewModel()
        {
            Id = s.Id,
            Link = s.Link,
            LogoPath = s.LogoPath,
        }).ToListAsync();
    }
}

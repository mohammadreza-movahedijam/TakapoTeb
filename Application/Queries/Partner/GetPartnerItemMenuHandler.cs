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

internal sealed class GetPartnerItemMenuHandler :
    IRequestHandler<GetPartnerItemMenuQuery, IReadOnlyList<PartnerItemMenuViewModel>>
{
    readonly IRepository<PartnerEntity> _repository;
    public GetPartnerItemMenuHandler(IRepository<PartnerEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<PartnerItemMenuViewModel>> Handle
        (GetPartnerItemMenuQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PartnerEntity> query = _repository.GetByQuery();
        return await query.Select(s => new PartnerItemMenuViewModel()
        {
            Id = s.Id,
           TitleEn=s.TitleEn,
           TitleFa=s.TitleFa,
        }).ToListAsync();
    }
}

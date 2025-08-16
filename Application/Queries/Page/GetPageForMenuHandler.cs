using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

internal sealed class GetPageForMenuHandler
    : IRequestHandler<GetPageForMenuQuery, IReadOnlyList<PageViewModel>>
{
    readonly IRepository<PageEntity> _pageRepository;
    public GetPageForMenuHandler(IRepository<PageEntity> pageRepository)
    {
        _pageRepository = pageRepository;
    }
    public async Task<IReadOnlyList<PageViewModel>> Handle
        (GetPageForMenuQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PageEntity> query =
            _pageRepository.GetByQuery();
        return await query.Where(w=>w.IsShowOnMenu==true).Select(s=> new PageViewModel()
        {
            Id = s.Id,
            IsShowOnMenu = s.IsShowOnMenu,
            TitleFa=s.TitleFa,
            TitleEn=s.TitleEn,
        }).ToListAsync();   
    }
}

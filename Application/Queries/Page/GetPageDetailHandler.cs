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

internal sealed class GetPageDetailHandler :
    IRequestHandler<GetPageDetailQuery, PageDetailViewModel>
{
    readonly IRepository<PageEntity> _pageRepository;
    public GetPageDetailHandler(IRepository<PageEntity> pageRepository)
    {
        _pageRepository = pageRepository;
    }
    public async Task<PageDetailViewModel> Handle(GetPageDetailQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<PageEntity> query =
           _pageRepository.GetByQuery();
        PageDetailViewModel? page= await query .Where(w=>w.Id==request.Id)
            .Select(s => new PageDetailViewModel()
        {
          
           DescriptionEn=s.DescriptionEn,
           DescriptionFa=s.DescriptionFa,
           ImagePath=s.ImagePath,
            TitleFa = s.TitleFa,
            TitleEn = s.TitleEn,
        }).FirstOrDefaultAsync();
        return page!;
    }
}

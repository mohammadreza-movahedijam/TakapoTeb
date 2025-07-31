using Application.Contract;
using Domain.Entities.System;
using Domain.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Catalog;

internal sealed class GetBookOrCatalogHandler :
    IRequestHandler<GetBookOrCatalogQuery, IReadOnlyList<CatalogDetailViewModel>>
{
    readonly IRepository<CatalogEntity> _catalogRepository;
    public GetBookOrCatalogHandler(IRepository<CatalogEntity> catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }
    public async Task<IReadOnlyList<CatalogDetailViewModel>> 
        Handle(GetBookOrCatalogQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CatalogEntity> query =
            _catalogRepository.GetByQuery();
        return await query.Where(w=>w.Type== request.Type).Select(s=>new CatalogDetailViewModel()
        {
            FilePath = s.FilePath,
            DescriptionEn=s.DescriptionEn,
            DescriptionFa=s.DescriptionFa,
            TitleEn=s.TitleEn,
            TitleFa = s.TitleFa 
        }).ToListAsync();
    }
}

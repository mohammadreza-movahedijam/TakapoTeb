using Application.Common;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.NewsCategory;

internal sealed class GetNewsCategoriesTabHandler :
    IRequestHandler<GetNewsCategoriesTabQuery, IReadOnlyList<NewsCategoryViewModel>>
{
    readonly IRepository<NewsCategoryEntity> _newsCategoryRepository;

    public GetNewsCategoriesTabHandler(IRepository<NewsCategoryEntity> newsCategoryRepository)
    {
        _newsCategoryRepository = newsCategoryRepository;
    }
    public async Task<IReadOnlyList<NewsCategoryViewModel>> Handle(GetNewsCategoriesTabQuery request, CancellationToken cancellationToken)
    {
        IQueryable<NewsCategoryEntity> query = _newsCategoryRepository.GetByQuery();
      
        return await query
            .OrderBy(b=>b.CreatedDate).Select(s => new NewsCategoryViewModel()
        {
            Id = s.Id,
            TitleEn=s.TitleEn,
            TitleFa=s.TitleFa,
        }).ToListAsync();
    }
}

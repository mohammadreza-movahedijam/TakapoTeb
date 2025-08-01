using Application.Common;
using Application.Contract;
using Application.Queries.BlogCategory;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.NewsCategory;

internal sealed class GetNewsCategoryItemHandler
:
    IRequestHandler<GetNewsCategoryItemQuery, IReadOnlyList<ItemGeneric<Guid, string>>>
{
    readonly IRepository<NewsCategoryEntity> _repository;
    public GetNewsCategoryItemHandler(IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }



    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        Handle(GetNewsCategoryItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<NewsCategoryEntity> query = _repository.GetByQuery();
        if (!string.IsNullOrEmpty(request.Search))
        {
            query = query.Where(w => w.TitleFa!.Contains(request.Search) ||
            w.TitleEn!.Contains(request.Search));
        }
        return await query.Select(s => new ItemGeneric<Guid, string>()
        {
            Id = s.Id,
            Title = s.TitleFa + " " + s.TitleEn
        }).ToListAsync();
    }
}

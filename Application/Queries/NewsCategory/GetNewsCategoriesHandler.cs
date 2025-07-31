using Application.Common.Extension;
using Application.Common;
using Application.Contract;
using Application.Queries.NewsCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.System;

namespace Application.Queries.NewsCategory;

internal sealed class GetNewsCategoriesHandler:
    IRequestHandler<GetNewsCategoriesQuery, PaginatedList<NewsCategoryViewModel>>
{

    readonly IRepository<NewsCategoryEntity> _repository;
    public GetNewsCategoriesHandler
        (IRepository<NewsCategoryEntity> repository)
    {
        _repository = repository;
    }



    public async Task<PaginatedList<NewsCategoryViewModel>>
        Handle(GetNewsCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<NewsCategoryEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize);
        int total = query.Count();

        PaginatedList<NewsCategoryViewModel> model =
            await query.MappingedAsync<NewsCategoryEntity, NewsCategoryViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

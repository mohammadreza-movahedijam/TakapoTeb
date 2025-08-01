using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Departement;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Page;

internal sealed class GetPagesHandler :
    IRequestHandler<GetPagesQuery, PaginatedList<PageViewModel>>
{
    readonly IRepository<PageEntity> _repository;
    public GetPagesHandler(IRepository<PageEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<PageViewModel>>
        Handle(GetPagesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PageEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleFa!.Contains(request!.Pagination!.keyword)
            || w.TitleEn!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<PageViewModel> model =
            await query.MappingedAsync<PageEntity, PageViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

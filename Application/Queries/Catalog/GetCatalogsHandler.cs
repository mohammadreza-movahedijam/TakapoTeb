using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Departement;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Catalog;

internal sealed class GetCatalogsHandler
    : IRequestHandler<GetCatalogsQuery, PaginatedList<CatalogViewModel>>
{
    readonly IRepository<CatalogEntity> _repository;
    public GetCatalogsHandler(IRepository<CatalogEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<CatalogViewModel>> Handle
        (GetCatalogsQuery request, CancellationToken cancellationToken)
    {

        IQueryable<CatalogEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleFa!.Contains(request!.Pagination!.keyword)
            || w.TitleEn!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<CatalogViewModel> model =
            await query.MappingedAsync<CatalogEntity, CatalogViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

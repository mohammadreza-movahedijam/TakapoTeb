using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Article.ViewModels;
using Domain.Entities.Blog;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Departement;

internal sealed class GetDepartementsHandler :
    IRequestHandler<GetDepartementsQuery, PaginatedList<DepartementViewModel>>
{
    readonly IRepository<DepartementEntity> _repository;
    public GetDepartementsHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<DepartementViewModel>>
        Handle(GetDepartementsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<DepartementEntity> query = _repository.GetByQuery();
       
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.NameFa!.Contains(request!.Pagination!.keyword)
            || w.NameEn!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<DepartementViewModel> model =
            await query.MappingedAsync<DepartementEntity, DepartementViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

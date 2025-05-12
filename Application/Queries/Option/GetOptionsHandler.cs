using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Product;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Option;

internal sealed class GetOptionsHandler :
    IRequestHandler<GetOptionsQuery,
        PaginatedList<OptionViewModel>>
{
    readonly IRepository<OptionEntity> _repository;

    public GetOptionsHandler
        (IRepository<OptionEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<OptionViewModel>>
        Handle(GetOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        IQueryable<OptionEntity> query = _repository.GetByQuery();
        query = query.Where(w => w.ProductId == request.ProductId);
        PaginatedList<OptionViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<OptionEntity, OptionViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

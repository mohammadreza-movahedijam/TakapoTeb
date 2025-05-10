using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Product;

internal sealed class GetProductsHandler :
    IRequestHandler<GetProductsQuery, PaginatedList<ProductViewModel>>
{
    readonly IRepository<ProductEntity> _repository;
    public GetProductsHandler(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<ProductViewModel>>
        Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<ProductEntity, ProductViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.CategoryTitle, s => s.Category!.TitleFa)
            .Map(d => d.Title, s => s.TitleFa)
            .Compile();

        IQueryable<ProductEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.Category);
        PaginatedList<ProductViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<ProductEntity, ProductViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}

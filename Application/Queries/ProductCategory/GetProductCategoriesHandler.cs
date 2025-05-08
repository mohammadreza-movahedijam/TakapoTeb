using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Role.ViewModel;
using Domain.Entities.Identity;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory;

internal sealed class GetProductCategoriesHandler :
    IRequestHandler<GetProductCategoriesQuery, PaginatedList<ProductCategoryViewModel>>
{
    readonly IRepository<ProductCategoryEntity> _repository;
    public GetProductCategoriesHandler
        (IRepository<ProductCategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<ProductCategoryViewModel>> Handle(GetProductCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<ProductCategoryEntity, ProductCategoryViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.ParentTitle, s =>
                s.ParentProductCategory != null ?
                    $"{s.ParentProductCategory.TitleFa} {s.ParentProductCategory.TitleEn}" : "")
            .Map(d => d.Title, s =>
                s != null && !string.IsNullOrEmpty(s.TitleFa) && !string.IsNullOrEmpty(s.TitleEn) ?
                    $"{s.TitleFa} {s.TitleEn}" : "")
            .Compile();

        IQueryable<ProductCategoryEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.ParentProductCategory);
        PaginatedList<ProductCategoryViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword)
            );
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<ProductCategoryEntity, ProductCategoryViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total,config);
        return model;
    }
}

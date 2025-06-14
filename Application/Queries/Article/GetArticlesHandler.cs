using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Article.ViewModels;
using Application.Queries.BlogCategory;
using Domain.Entities.Blog;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Article;

internal sealed class GetArticlesHandler :
    IRequestHandler<GetArticlesQuery, PaginatedList<ArticleViewModel>>
{
    readonly IRepository<ArticleEntity> _repository;
    public GetArticlesHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<ArticleViewModel>> Handle
        (GetArticlesQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<ArticleEntity,ArticleViewModel>()
            .Map(d=>d.Id,s=>s.Id)
            .Map(d=>d.CategoryTitleEn,s=>s.Category!.TitleEn)
            .Map(d=>d.CategoryTitleFa, s=> s.Category!.TitleFa)
            .Map(d=>d.ImagePath,s=>s.ImagePath)
            .Map(d=>d.TitleFa,s=>s.TitleFa)
            .Map(d=>d.TitleEn,s=>s.TitleEn).Compile();

        IQueryable<ArticleEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.Category);
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<ArticleViewModel> model =
            await query.MappingedAsync<ArticleEntity, ArticleViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}

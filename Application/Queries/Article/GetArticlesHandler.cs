using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.BlogCategory;
using Domain.Entities.Blog;
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
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

using Application.Common;
using Application.Contract;
using Application.Queries.Article.ViewModels;
using MediatR;

namespace Application.Queries.Article;

public sealed record GetArticlesQuery :
    IRequest<PaginatedList<ArticleViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetArticlesQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}

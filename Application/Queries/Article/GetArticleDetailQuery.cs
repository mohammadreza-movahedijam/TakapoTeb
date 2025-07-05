using Application.Queries.Article.ViewModels;
using MediatR;

namespace Application.Queries.Article;

public sealed record GetArticleDetailQuery : IRequest<ArticleDetailViewModel>
{
    public Guid Id { get; set; }
}

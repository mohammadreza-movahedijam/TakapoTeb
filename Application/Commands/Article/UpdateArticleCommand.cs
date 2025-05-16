using MediatR;

namespace Application.Commands.Article;

public sealed record UpdateArticleCommand :
    IRequest
{
    public ArticleDto Article { get; set; }
    public UpdateArticleCommand(ArticleDto Article)
    {
        this.Article = Article;
    }
}

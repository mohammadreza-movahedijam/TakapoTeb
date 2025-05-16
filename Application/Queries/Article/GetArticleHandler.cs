using Application.Commands.Article;
using Application.Contract;
using Domain.Entities.Blog;
using MediatR;

namespace Application.Queries.Article;

internal sealed class GetArticleHandler :
    IRequestHandler<GetArticleQuery, ArticleDto>
{
    readonly IRepository<ArticleEntity> _repository;
    public GetArticleHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task<ArticleDto> Handle(GetArticleQuery request,
        CancellationToken cancellationToken)
    {
        ArticleDto article=
            await _repository.GetAsync<ArticleDto>
            (g=>g.Id==request.Id,null,cancellationToken);
        if(article is null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        return article;
    }
}

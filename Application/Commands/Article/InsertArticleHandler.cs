using Domain.Entities.Blog;
using MediatR;
using Application.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Application.Common.Extension;

namespace Application.Commands.Article;

internal sealed class InsertArticleHandler :
    IRequestHandler<InsertArticleCommand>
{
    readonly IRepository<ArticleEntity> _repository;
    public InsertArticleHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }

    public async Task Handle(InsertArticleCommand request, 
        CancellationToken cancellationToken)
    {
        ArticleEntity article =
            request.Article.Adapt<ArticleEntity>();
        if (request.Article.ImageFile != null) 
        {
            article.ImagePath = request.Article.ImageFile.UploadImage("Article");
        }
        await _repository.InsertAsync(article,cancellationToken);
    }
}

using Domain.Entities.Blog;
using MediatR;
using Application.Contract;
using Mapster;
using Application.Common.Extension;
namespace Application.Commands.Article;

internal sealed class UpdateArticleHandler :
    IRequestHandler<UpdateArticleCommand>
{
    readonly IRepository<ArticleEntity> _repository;
    public UpdateArticleHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateArticleCommand request, 
        CancellationToken cancellationToken)
    {
        ArticleEntity? article=await
            _repository.GetAsync(g=>g.Id==request.Article.Id, 
            cancellationToken);
        if (article == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Article.Adapt(article);
        if (request.Article.ImageFile != null)
        {
            var ImagePath = request.Article.ImageFile.UploadImage("Article");
            request.Article.ImagePath!.RemoveImage("Article");
        article.ImagePath = ImagePath;
        }
      
        await _repository.UpdateAsync(article, cancellationToken);
    }
}

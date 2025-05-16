using Application.Contract;
using Domain.Entities.Blog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Article;

internal sealed class DeleteArticleHandler :
    IRequestHandler<DeleteArticleCommand>
{
    readonly IRepository<ArticleEntity> _repository;
    public DeleteArticleHandler(IRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteArticleCommand request, 
        CancellationToken cancellationToken)
    {
        ArticleEntity? article = await
           _repository.GetAsync(g => g.Id == request.Id,
           cancellationToken);
        if (article == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        article.IsDeleted = true;
         await _repository.UpdateAsync(article, cancellationToken);
    }
}

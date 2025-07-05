using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.News;

internal sealed class DeleteNewsHandler :
    IRequestHandler<DeleteNewsCommand>
{
    readonly IRepository<NewsEntity> _newsRepository;
    public DeleteNewsHandler(IRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;
    }
    public async Task Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        NewsEntity? news = await _newsRepository.GetAsync(g => g.Id == request.Id, cancellationToken);
        if (news == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        news.IsDeleted = true;
        await _newsRepository.UpdateAsync(news, cancellationToken);
    }
}

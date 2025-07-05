using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.News;

internal sealed class UpdateNewsHandler :
    IRequestHandler<UpdateNewsCommand>
{
    readonly IRepository<NewsEntity> _newsRepository;
    public UpdateNewsHandler(IRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;
    }
    public async Task Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        NewsEntity? news=await _newsRepository.GetAsync(g=>g.Id==request.News.Id,cancellationToken);
        if (news == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.News.Adapt(news);
        if (request.News!.ImageFile is not null)
        {
            news.ImagePath = request.News.ImageFile.UploadImage("News");
            request.News.ImagePath!.RemoveImage("News");
        }
        await _newsRepository.UpdateAsync(news,cancellationToken);
    
    }
}

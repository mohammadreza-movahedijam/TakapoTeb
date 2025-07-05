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

internal sealed class InsertNewsHandler :
    IRequestHandler<InsertNewsCommand>
{
    readonly IRepository<NewsEntity> _newsRepository;
    public InsertNewsHandler(IRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public async Task Handle(InsertNewsCommand request, 
        CancellationToken cancellationToken)
    {
        NewsEntity news=request.News.Adapt<NewsEntity>();
        if (request.News!.ImageFile is not null) 
        {
            news.ImagePath = request.News.ImageFile.UploadImage("News");
        }
        await _newsRepository.InsertAsync(news,cancellationToken);
    }
}

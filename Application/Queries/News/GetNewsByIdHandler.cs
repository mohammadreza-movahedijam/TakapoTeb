using Application.Commands.News;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

internal sealed class GetNewsByIdHandler :
    IRequestHandler<GetNewsByIdQuery, NewsDto>
{
    readonly IRepository<NewsEntity> _newsRepository;
    public GetNewsByIdHandler(IRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;   
    }
    public async Task<NewsDto> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
    {
        NewsDto? news=await _newsRepository.
            GetAsync<NewsDto>(g=>g.Id==request.Id,cancellation:cancellationToken);
        if (news == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return news;
    }
}

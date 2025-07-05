using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

internal sealed class GetNewsDetailHandler :
    IRequestHandler<GetNewsDetailQuery, NewsDetailViewModel>
{
    readonly IRepository<NewsEntity> _newsRepository;
    public GetNewsDetailHandler(IRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;
    }
    public async Task<NewsDetailViewModel> Handle(GetNewsDetailQuery request, CancellationToken cancellationToken)
    {
        NewsDetailViewModel newsDetailView=
            await _newsRepository.GetAsync<NewsDetailViewModel>(g=>g.Id==request.Id,null,cancellationToken);
        return newsDetailView;
    }
}

using Application.Common.Extension;
using Application.Common;
using Application.Contract;
using Application.Queries.Video;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.System;

namespace Application.Queries.Video;

internal sealed class GetVideosHandler :
    IRequestHandler<GetVideosQuery, PaginatedList<VideoViewModel>>
{
    readonly IRepository<VideoEntity> _repository;
    public GetVideosHandler(IRepository<VideoEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<VideoViewModel>> Handle
        (GetVideosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<VideoEntity> query = _repository.GetByQuery();
        query = query.Where(w => w.EventId == request.EventId);
        PaginatedList<VideoViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<VideoEntity, VideoViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

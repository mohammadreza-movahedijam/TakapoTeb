using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Video;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Picture;

internal sealed class GetPicturesHandler :
    IRequestHandler<GetPicturesQuery, PaginatedList<PictureViewModel>>
{
    readonly IRepository<PictureEntity> _repository;
    public GetPicturesHandler(IRepository<PictureEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<PictureViewModel>> Handle(GetPicturesQuery request, CancellationToken cancellationToken)
    {

        IQueryable<PictureEntity> query = _repository.GetByQuery();
        query = query.Where(w => w.EventId == request.EventId);
        PaginatedList<PictureViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleEn!.Contains(request!.Pagination!.keyword)
            || w.TitleFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<PictureEntity, PictureViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

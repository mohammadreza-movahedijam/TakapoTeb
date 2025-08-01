using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Event;

internal sealed class GetEventsDetailHandler :
    IRequestHandler<GetEventsDetailQuery,
        IReadOnlyList<EventDetailViewModel>>
{
    readonly IRepository<EventEntity> _eventRepository;
    public GetEventsDetailHandler(IRepository<EventEntity> eventRepository)
    {
       _eventRepository = eventRepository;
    }
    public async Task<IReadOnlyList<EventDetailViewModel>> Handle
        (GetEventsDetailQuery request, CancellationToken cancellationToken)
    {
        IQueryable<EventEntity> query = _eventRepository.GetByQuery();
        IReadOnlyList<EventDetailViewModel> models=
            await query.Include(i=>i.Videos)
            .Include(i=>i.Pictures)
            .Select(s=> new EventDetailViewModel()
            {
                DescriptionFa=s.DescriptionFa,
                DescriptionEn=s.DescriptionEn,
                TitleEn=s.TitleEn,
                TitleFa=s.TitleFa,
                Videos=s.Videos.Adapt<List<EventVideoViewModel>>() ?? new List<EventVideoViewModel>(),
                Pictures=s.Pictures.Adapt<List<EventPictureViewModel>>()?? new List<EventPictureViewModel>()
            }).ToListAsync();

        return models;
    }
}

using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Slider;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Event;

internal sealed class GetEventsHandler :
    IRequestHandler<GetEventsQuery, PaginatedList<EventViewModel>>
{
    readonly IRepository<EventEntity> _eventRepository;
    public GetEventsHandler(IRepository<EventEntity> eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task<PaginatedList<EventViewModel>>
        Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {

        IQueryable<EventEntity> query = _eventRepository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.TitleFa!.Contains(request!.Pagination!.keyword)
            || w.TitleEn!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize);
        int total = query.Count();

        PaginatedList<EventViewModel> model =
            await query.MappingedAsync<EventEntity, EventViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

using Application.Commands.Event;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Event;

internal sealed class GetEventHandler :
    IRequestHandler<GetEventQuery, EventDto>
{

    readonly IRepository<EventEntity> _repository;
    public GetEventHandler(IRepository<EventEntity> repository)
    {
        _repository = repository;
    }
    public async Task<EventDto> Handle(GetEventQuery request,
        CancellationToken cancellationToken)
    {
        EventDto eventDto=await _repository.GetAsync<EventDto>
            (g=>g.Id == request.Id,null,cancellationToken);
        if(eventDto is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return eventDto;
    }
}

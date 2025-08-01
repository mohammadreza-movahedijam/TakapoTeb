using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Event;

internal sealed class InsertEventHandler :
    IRequestHandler<InsertEventCommand>
{
    readonly IRepository<EventEntity> _repository;
    public InsertEventHandler(IRepository<EventEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertEventCommand request,
        CancellationToken cancellationToken)
    {
        EventEntity entity = request.Event.Adapt<EventEntity>();
        await _repository.InsertAsync(entity, cancellationToken);
    }
}

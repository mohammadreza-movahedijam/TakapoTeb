using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Event;

internal sealed class UpdateEventHandler :
    IRequestHandler<UpdateEventCommand>
{
    readonly IRepository<EventEntity> _repository;
    public UpdateEventHandler(IRepository<EventEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateEventCommand request,
        CancellationToken cancellationToken)
    {
        EventEntity? eventEntity =
            await _repository.GetAsync
            (g => g.Id == request.Event!.Id, cancellationToken);
        if (eventEntity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Event.Adapt(eventEntity);
        await _repository.UpdateAsync(eventEntity, cancellationToken);
    }
}

using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Event;

internal sealed class DeleteEventHandler :
    IRequestHandler<DeleteEventCommand>
{
    readonly IRepository<EventEntity> _repository;
    public DeleteEventHandler(IRepository<EventEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        EventEntity? eventEntity =
            await _repository.GetAsync
            (g => g.Id == request!.Id, cancellationToken);
        if (eventEntity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        eventEntity.IsDeleted = true;
        await _repository.UpdateAsync(eventEntity, cancellationToken);
    }
}

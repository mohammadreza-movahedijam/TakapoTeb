using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Message;

internal sealed class DeleteMessageHandler :
    IRequestHandler<DeleteMessageCommand>
{
    readonly IRepository<MessageEntity> _messageRepository;
    public DeleteMessageHandler(IRepository<MessageEntity> messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        MessageEntity? message=await _messageRepository
            .GetAsync(g=>g.Id == request.Id,cancellationToken);

        if(message is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        message.IsDeleted = true;
        await _messageRepository.UpdateAsync(message, cancellationToken);
    }
}

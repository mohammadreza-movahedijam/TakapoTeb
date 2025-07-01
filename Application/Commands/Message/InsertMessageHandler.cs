using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Message;

internal sealed class InsertMessageHandler : IRequestHandler<InsertMessageCommand>
{
    readonly IRepository<MessageEntity> _messageRepository;
    public InsertMessageHandler(IRepository<MessageEntity> messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task Handle(InsertMessageCommand request, CancellationToken cancellationToken)
    {
        MessageEntity message=request.Message.Adapt<MessageEntity>();   
        await _messageRepository.InsertAsync(message,cancellationToken);
    }
}

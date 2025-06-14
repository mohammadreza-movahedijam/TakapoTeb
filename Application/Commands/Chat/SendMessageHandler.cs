using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Chat;

internal sealed class SendMessageHandler :
    IRequestHandler<SendMessageCommand>
{

    readonly IRepository<ChatMessageEntity> _chatMessageRepository;
    public SendMessageHandler(IRepository<ChatMessageEntity> chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }
    public async Task Handle(SendMessageCommand request,
        CancellationToken cancellationToken)
    {

        ChatMessageEntity message = new();
        message.IPAddress = request.Message!.IPAddress;
        message.Message = request.Message.Message;
        message.ChatGroupId = Guid.Parse(request.Message.ChatGroupId!);
        message.UserType = request.Message.UserType;

        await _chatMessageRepository.InsertAsync(message, cancellationToken);

    }
}

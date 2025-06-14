using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Chat;

internal sealed class JoinChatGroupHandler :
    IRequestHandler<JoinChatGroupCommand, string>
{
    readonly IRepository<ChatGroupEntity> _chatGroupRepository;
    public JoinChatGroupHandler(IRepository<ChatGroupEntity> chatGroupRepository)
    {
        _chatGroupRepository = chatGroupRepository;
    }
    public async Task<string> Handle(JoinChatGroupCommand request, 
        CancellationToken cancellationToken)
    {
        ChatGroupEntity? group=await _chatGroupRepository
            .GetAsync(g=>g.ConnectionId==
            request.ChatGroup!.ConnectionId, 
            cancellationToken);
        if (group == null)
        {
            group = new();
            group.ConnectionId = request.ChatGroup!.ConnectionId;
            group.IPAddress = request.ChatGroup!.IPAddress;
            await _chatGroupRepository.InsertAsync(group,cancellationToken);
        }
        return group.Id.ToString()!;
    }
}

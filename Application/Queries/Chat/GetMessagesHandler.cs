using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Chat;

internal sealed class GetMessagesHandler :
    IRequestHandler<GetMessagesQuery, IReadOnlyList<MessageViewModel>>
{
    readonly IRepository<ChatMessageEntity> _chatMessageRepository;
    public GetMessagesHandler(IRepository<ChatMessageEntity> chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }
    public async Task<IReadOnlyList<MessageViewModel>> Handle
        (GetMessagesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ChatMessageEntity> query = _chatMessageRepository
            .GetByQuery();

        return await query.AsNoTracking()
            .Where(w=>w.ChatGroupId==request.Id)
          
            .Select(s=>new MessageViewModel()
            {
                UserType=s.UserType==Domain.Types.UserType.User? "user-message" : "support-message",
                CreateAt=s.CreateAt.PersianDateWithTime(),
                Message=s.Message
            }).ToListAsync();   
    }
}

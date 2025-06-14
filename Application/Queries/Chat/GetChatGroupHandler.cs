using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Chat;

internal sealed class GetChatGroupHandler :
    IRequestHandler<GetChatGroupQuery, IReadOnlyList<ChatGroupViewModel>>
{
    readonly IRepository<ChatGroupEntity> _chatGroupRepository;
    public GetChatGroupHandler(IRepository<ChatGroupEntity> chatGroupRepository)
    {
        _chatGroupRepository = chatGroupRepository;
    }
    public async Task<IReadOnlyList<ChatGroupViewModel>>
        Handle(GetChatGroupQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ChatGroupEntity> query = _chatGroupRepository
            .GetByQuery();
        return await query.Include(i => i.chatMessages)
            .AsNoTracking()
            .Where(w => w.chatMessages!.Any())
            .OrderByDescending(o=>o.CreateAt)
            .Select(s => new ChatGroupViewModel()
            {
                ConnectionId = s.ConnectionId,
                Id = s.Id,
                IPAddress = s.IPAddress,
                CreateAt = s.CreateAt.PersianDateWithTime()
            }).ToListAsync();
    }
}

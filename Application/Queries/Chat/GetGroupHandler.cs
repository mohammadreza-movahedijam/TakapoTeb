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

internal sealed class GetGroupHandler :
    IRequestHandler<GetGroupQuery, ChatGroupViewModel>
{
    readonly IRepository<ChatGroupEntity> _chatGroupRepository;
    public GetGroupHandler(IRepository<ChatGroupEntity> chatGroupRepository)
    {
        _chatGroupRepository = chatGroupRepository;
    }
    public async Task<ChatGroupViewModel> Handle(GetGroupQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<ChatGroupEntity> query =
            _chatGroupRepository.GetByQuery();

        ChatGroupViewModel? model = await query.AsNoTracking()
            .Include(i => i.chatMessages)
            .Where(w => w.ConnectionId == request.ConnectionId)
            .Select(s => new ChatGroupViewModel()
            {
                ConnectionId = s.ConnectionId,
                CountMessage = s.chatMessages.Count(),
                CreateAt = s.CreateAt.PersianDateWithTime(),
                Id = s.Id,
            }).FirstOrDefaultAsync();
        return model!;
    }
}

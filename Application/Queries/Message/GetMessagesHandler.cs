using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Departement;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Message;

internal sealed class GetMessagesHandler :
    IRequestHandler<GetMessagesQuery, PaginatedList<MessageViewModel>>
{

    readonly IRepository<MessageEntity> _messageRepository;
    public GetMessagesHandler(IRepository<MessageEntity> messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task<PaginatedList<MessageViewModel>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {


        IQueryable<MessageEntity> query = _messageRepository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.FullName!.Contains(request!.Pagination!.keyword)
            || w.Subject!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<MessageViewModel> model =
            await query.MappingedAsync<MessageEntity, MessageViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

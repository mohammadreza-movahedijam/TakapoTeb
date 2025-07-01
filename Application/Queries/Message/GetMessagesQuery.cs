using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Message;

public sealed record GetMessagesQuery : IRequest<PaginatedList<MessageViewModel>>
{
    public IPagination? Pagination { get; set; }
}

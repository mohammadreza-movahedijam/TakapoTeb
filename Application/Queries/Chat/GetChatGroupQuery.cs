using MediatR;

namespace Application.Queries.Chat;

public sealed record GetChatGroupQuery : IRequest<IReadOnlyList<ChatGroupViewModel>>
{
}

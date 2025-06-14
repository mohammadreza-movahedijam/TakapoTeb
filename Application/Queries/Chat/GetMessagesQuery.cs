using MediatR;

namespace Application.Queries.Chat;

public sealed record GetMessagesQuery : IRequest<IReadOnlyList<MessageViewModel>>
{
    public Guid Id { get; set; }
}

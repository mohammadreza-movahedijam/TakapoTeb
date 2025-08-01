using MediatR;

namespace Application.Queries.Event;

public sealed record GetEventsDetailQuery
    : IRequest<IReadOnlyList<EventDetailViewModel>>
{
}

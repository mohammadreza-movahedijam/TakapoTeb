using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Feedback;

public sealed record GetFeedbacksQuery : IRequest<PaginatedList<FeedbackViewModel>>
{
    public IPagination Pagination { get; set; }
}

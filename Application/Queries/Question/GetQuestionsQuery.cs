using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Question;

public sealed record GetQuestionsQuery
    : IRequest<PaginatedList<QuestionViewModel>>
{
    public IPagination? Pagination { get; set; }
}

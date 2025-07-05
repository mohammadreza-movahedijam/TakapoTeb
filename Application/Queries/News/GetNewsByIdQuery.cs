using Application.Commands.News;
using MediatR;

namespace Application.Queries.News;

public sealed record GetNewsByIdQuery : IRequest<NewsDto>
{
    public Guid Id { get; set; }
}

using Application.Commands.Statistic;
using MediatR;

namespace Application.Queries.Statistic;

public sealed record GetStatisticQuery:IRequest<StatisticDto>
{
}

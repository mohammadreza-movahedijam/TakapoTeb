using MediatR;

namespace Application.Commands.Statistic;
public sealed record ChangeStatisticCommand : IRequest
{
    public StatisticDto? Statistic { get; set; }
}

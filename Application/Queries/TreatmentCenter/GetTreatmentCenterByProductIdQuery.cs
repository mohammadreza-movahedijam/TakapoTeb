using MediatR;

namespace Application.Queries.TreatmentCenter;

public sealed record GetTreatmentCenterByProductIdQuery :
    IRequest<IReadOnlyList<TreatmentCenterViewModel>>
{
    public Guid ProductId { get; set; }
}

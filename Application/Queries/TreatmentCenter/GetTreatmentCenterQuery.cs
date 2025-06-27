using Application.Commands.TreatmentCenter;
using MediatR;

namespace Application.Queries.TreatmentCenter;

public sealed record GetTreatmentCenterQuery : IRequest<TreatmentCenterDto>
{
    public Guid Id { get; set; }
}

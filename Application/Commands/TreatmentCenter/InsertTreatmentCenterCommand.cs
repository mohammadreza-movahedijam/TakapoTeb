using MediatR;

namespace Application.Commands.TreatmentCenter;

public sealed record InsertTreatmentCenterCommand : IRequest
{
    public TreatmentCenterDto? TreatmentCenter { get; set; }
}

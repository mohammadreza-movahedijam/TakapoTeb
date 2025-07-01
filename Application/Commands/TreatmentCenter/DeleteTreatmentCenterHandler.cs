using Application.Contract;
using Domain.Entities.Product;
using MediatR;
namespace Application.Commands.TreatmentCenter;
internal sealed class DeleteTreatmentCenterHandler
    : IRequestHandler<DeleteTreatmentCenterCommand>
{
    readonly IRepository<TreatmentCenterEntity> _treatmentCenterRepository;
    public DeleteTreatmentCenterHandler
        (IRepository<TreatmentCenterEntity> treatmentCenterRepository)
    {
        _treatmentCenterRepository = treatmentCenterRepository;
    }
    public async Task Handle(DeleteTreatmentCenterCommand request,
        CancellationToken cancellationToken)
    {
        TreatmentCenterEntity? treatmentCenter = await _treatmentCenterRepository
          .GetAsync(g => g.Id == request.Id, cancellationToken);
        if (treatmentCenter == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        treatmentCenter.IsDeleted = true;
        await _treatmentCenterRepository.UpdateAsync(treatmentCenter, cancellationToken);
    }
}

using Application.Contract;
using MediatR;
using Domain.Entities.Product;
using Mapster;
using Application.Common.Extension;

namespace Application.Commands.TreatmentCenter;

internal sealed class InsertTreatmentCenterHandler :
    IRequestHandler<InsertTreatmentCenterCommand>
{
    readonly IRepository<TreatmentCenterEntity> _treatmentCenterRepository;
    public InsertTreatmentCenterHandler(IRepository<TreatmentCenterEntity> treatmentCenterRepository)
    {
        _treatmentCenterRepository = treatmentCenterRepository;
    }
    public async Task Handle(InsertTreatmentCenterCommand request,
        CancellationToken cancellationToken)
    {
        TreatmentCenterEntity treatmentCenter =
            request.TreatmentCenter.Adapt<TreatmentCenterEntity>();

        if (request.TreatmentCenter!.ImageFile is not null)
        {
            treatmentCenter.Image = request.TreatmentCenter.ImageFile.UploadImage("TreatmentCenter");
        }

        await _treatmentCenterRepository.
            InsertAsync(treatmentCenter,cancellationToken);
    }
}

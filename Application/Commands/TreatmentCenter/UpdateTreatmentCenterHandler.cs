using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TreatmentCenter;

internal sealed class UpdateTreatmentCenterHandler :
    IRequestHandler<UpdateTreatmentCenterCommand>
{
    readonly IRepository<TreatmentCenterEntity> _treatmentCenterRepository;

    public UpdateTreatmentCenterHandler(IRepository<TreatmentCenterEntity> treatmentCenterRepository)
    {
        _treatmentCenterRepository = treatmentCenterRepository;
    }
    public async Task Handle(UpdateTreatmentCenterCommand request,
        CancellationToken cancellationToken)
    {
        TreatmentCenterEntity? treatmentCenter=
            await _treatmentCenterRepository.GetAsync
            (g=>g.Id==request.TreatmentCenter!.Id, cancellationToken);

        if (treatmentCenter == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.TreatmentCenter.Adapt(treatmentCenter);

        if (request.TreatmentCenter!.ImageFile is not null)
        {
            treatmentCenter.Image =
                request.TreatmentCenter.ImageFile.UploadImage("News");
            request.TreatmentCenter.ImagePath!.RemoveImage("News");
        }

        await _treatmentCenterRepository.UpdateAsync(treatmentCenter, cancellationToken);

    }
}

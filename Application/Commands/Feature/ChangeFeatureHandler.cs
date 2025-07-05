using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Feature;

internal sealed class ChangeFeatureHandler :
    IRequestHandler<ChangeFeatureCommand>
{
    readonly IRepository<FeatureEntity> _repository;
    public ChangeFeatureHandler(IRepository<FeatureEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(ChangeFeatureCommand request,
        CancellationToken cancellationToken)
    {

        IQueryable<FeatureEntity> query = _repository.GetByQuery();
        FeatureEntity? feature = await query.FirstOrDefaultAsync();

        request.Feature.Adapt(feature);


        if (request.Feature.FileImageFour != null)
        {
            feature!.ImageFour = request.Feature.FileImageFour.UploadImage("feature");
            request.Feature.ImageFour!.RemoveImage("feature");
        }

        if (request.Feature.FileImageThree != null)
        {
            feature!.ImageThree = request.Feature.FileImageThree.UploadImage("feature");
            request.Feature.ImageThree!.RemoveImage("feature");
        }

        if (request.Feature.FileImageTwo != null)
        {
            feature!.ImageTwo = request.Feature.FileImageTwo.UploadImage("feature");
            request.Feature.ImageTwo!.RemoveImage("feature");
        }

        if (request.Feature.FileImageOne != null)
        {
            feature!.ImageOne = request.Feature.FileImageOne.UploadImage("feature");
            request.Feature.ImageOne!.RemoveImage("feature");
        }
        await _repository.UpdateAsync(feature!, cancellationToken);

    }
}

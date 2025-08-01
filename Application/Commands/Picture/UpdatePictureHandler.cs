using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Picture;

internal sealed class UpdatePictureHandler :
    IRequestHandler<UpdatePictureCommand>
{
    readonly IRepository<PictureEntity> _repository;
    public UpdatePictureHandler(IRepository<PictureEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdatePictureCommand request,
        CancellationToken cancellationToken)
    {
        PictureEntity? picture=await _repository
            .GetAsync(g=>g.Id ==request.Picture!.Id,cancellationToken);

        if (picture == null) {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        request.Picture.Adapt(picture);
        if (request.Picture!.File is not null) {
            picture.FilePath = request.Picture.File.UploadImage("Picture");
            request.Picture.FilePath!.RemoveImage("Picture");
        }
        await _repository.UpdateAsync(picture,cancellationToken);
    }
}

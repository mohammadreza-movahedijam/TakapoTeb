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

internal sealed class InsertPictureHandler :
    IRequestHandler<InsertPictureCommand>
{
    readonly IRepository<PictureEntity> _repository;
    public InsertPictureHandler(IRepository<PictureEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertPictureCommand request,
        CancellationToken cancellationToken)
    {
        PictureEntity picture = request.Picture.Adapt<PictureEntity>();
        if (request!.Picture!.File is not null) 
        {
            picture.FilePath = request.Picture.File.UploadImage("Picture");
        }

        await _repository.InsertAsync(picture,cancellationToken);

    }
}

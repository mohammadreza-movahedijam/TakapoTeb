using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Picture;

internal sealed class DeletePictureHandler :
    IRequestHandler<DeletePictureCommand>
{
    readonly IRepository<PictureEntity> _repository;
    public DeletePictureHandler(IRepository<PictureEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeletePictureCommand request, CancellationToken cancellationToken)
    {
        PictureEntity? picture = await _repository
           .GetAsync(g => g.Id == request!.Id, cancellationToken);

        if (picture == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        picture.IsDeleted = true;
        await _repository.UpdateAsync(picture, cancellationToken);
    }
}

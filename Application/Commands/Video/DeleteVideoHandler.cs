using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Video;

internal sealed class DeleteVideoHandler :
    IRequestHandler<DeleteVideoCommand>
{
    readonly IRepository<VideoEntity> _repository;
    public DeleteVideoHandler(IRepository<VideoEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
    {
        VideoEntity? video = await _repository
            .GetAsync(g => g.Id == request!.Id, cancellationToken);
        if (video == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
       video.IsDeleted = true;
        await _repository.UpdateAsync(video, cancellationToken);
    }
}

using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Video;

internal sealed class UpdateVideoHandler :
    IRequestHandler<UpdateVideoCommand>
{
    readonly IRepository<VideoEntity> _repository;
    public UpdateVideoHandler(IRepository<VideoEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateVideoCommand request,
        CancellationToken cancellationToken)
    {
        VideoEntity? video=await _repository
            .GetAsync(g=>g.Id==request.Video!.Id, cancellationToken);
        if(video == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Video.Adapt(video);
        await _repository.UpdateAsync(video,cancellationToken);
    }
}

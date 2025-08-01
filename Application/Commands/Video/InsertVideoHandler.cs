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

internal sealed class InsertVideoHandler :
    IRequestHandler<InsertVideoCommand>
{
    readonly IRepository<VideoEntity> _repository;
    public InsertVideoHandler(IRepository<VideoEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertVideoCommand request,
        CancellationToken cancellationToken)
    {
        VideoEntity video = request.Video.Adapt<VideoEntity>();
        await _repository.InsertAsync(video,cancellationToken);
    }
}

using Application.Commands.Video;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Video;

internal sealed class GetVideoHandler :
    IRequestHandler<GetVideoQuery, VideoDto>
{

    readonly IRepository<VideoEntity> _repository;
    public GetVideoHandler(IRepository<VideoEntity> repository)
    {
        _repository = repository;
    }
    public async Task<VideoDto> Handle(GetVideoQuery request, 
        CancellationToken cancellationToken)
    {
        VideoDto video=await _repository
            .GetAsync<VideoDto>(g=>g.Id == request.Id,null,cancellationToken);
        if (video == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return video;
    }
}

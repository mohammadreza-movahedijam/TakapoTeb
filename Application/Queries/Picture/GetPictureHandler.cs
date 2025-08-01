using Application.Commands.Picture;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Picture;

internal sealed class GetPictureHandler :
    IRequestHandler<GetPictureQuery, PictureDto>
{
    readonly IRepository<PictureEntity> _repository;
    public GetPictureHandler(IRepository<PictureEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PictureDto> Handle(GetPictureQuery request, CancellationToken cancellationToken)
    {
        PictureDto picture = await _repository
            .GetAsync<PictureDto>(g => g.Id == request.Id, null, cancellationToken);

        if(picture is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return picture;
    }
}

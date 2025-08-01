using Application.Commands.Picture;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Picture;

public sealed record GetPictureQuery:IRequest<PictureDto>
{
    public Guid Id { get; set; }
}

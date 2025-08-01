using Application.Commands.Video;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Video;

public sealed record GetVideoQuery:IRequest<VideoDto>
{
    public Guid Id  { get; set; }
}

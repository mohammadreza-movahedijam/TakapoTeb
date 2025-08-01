using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Video;

public sealed record UpdateVideoCommand:IRequest
{
    public VideoDto? Video { get; set; }
}

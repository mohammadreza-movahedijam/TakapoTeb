using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Picture;

public sealed record InsertPictureCommand:IRequest
{
    public PictureDto? Picture { get; set; }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Image;

public sealed record GetImagesQuery:IRequest<IReadOnlyList<ImageViewModel>>
{
    public Guid ProductId { get; set; }
}

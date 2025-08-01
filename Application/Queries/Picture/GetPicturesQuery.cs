using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Picture;

public sealed record GetPicturesQuery:IRequest<PaginatedList<PictureViewModel>>
{
    public Guid EventId { get; set; }
    public IPagination? Pagination { get; set; }
}

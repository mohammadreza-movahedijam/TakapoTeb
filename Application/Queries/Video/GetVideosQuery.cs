using Application.Common;
using Application.Contract;
using Application.Queries.Document;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Video;

public sealed record GetVideosQuery : IRequest<PaginatedList<VideoViewModel>>
{
    public Guid EventId { get; set; }
    public IPagination Pagination { get; set; }
    public GetVideosQuery(in Guid EventId, IPagination Pagination)
    {
        this.EventId = EventId;
        this.Pagination = Pagination;
    }
}

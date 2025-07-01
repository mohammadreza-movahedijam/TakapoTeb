using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TreatmentCenter;

public sealed record GetTreatmentCentersQuery:
    IRequest<PaginatedList<TreatmentCenterViewModel>>
{
    public Guid ProductId { get; set; }
    public IPagination Pagination { get; set; }
}

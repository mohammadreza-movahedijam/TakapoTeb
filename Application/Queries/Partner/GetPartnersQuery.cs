using Application.Common;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Partner;

public sealed record GetPartnersQuery:IRequest<PaginatedList<PartnerViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetPartnersQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}

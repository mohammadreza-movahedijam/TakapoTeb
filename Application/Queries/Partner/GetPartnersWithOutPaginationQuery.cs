using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Partner;

public sealed record GetPartnersWithOutPaginationQuery:
    IRequest<IReadOnlyList<PartnerViewModel>>
{
}

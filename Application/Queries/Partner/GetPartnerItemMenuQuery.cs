using MediatR;

namespace Application.Queries.Partner;

public sealed record GetPartnerItemMenuQuery:
    IRequest<IReadOnlyList<PartnerItemMenuViewModel>>
{
}

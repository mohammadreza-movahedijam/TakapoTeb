using Application.Commands.Partner;
using MediatR;

namespace Application.Queries.Partner;
public sealed record GetPartnerQuery : IRequest<PartnerDto>
{
    public Guid Id { get; set; }
    public GetPartnerQuery(in Guid Id)
    {
        this.Id = Id;
    }
}

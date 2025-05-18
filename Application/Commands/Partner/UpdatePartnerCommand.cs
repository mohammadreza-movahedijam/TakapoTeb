using MediatR;

namespace Application.Commands.Partner;

public sealed record UpdatePartnerCommand:IRequest
{
    public PartnerDto Partner { get; set; }
    public UpdatePartnerCommand(PartnerDto Partner)
    {
        this.Partner = Partner;
    }
}

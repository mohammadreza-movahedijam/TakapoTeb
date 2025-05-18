using MediatR;

namespace Application.Commands.Partner;
public sealed record DeletePartnerCommand : IRequest
{
    public Guid Id { get; set; }
    public DeletePartnerCommand(in Guid Id)
    {
        this.Id = Id;
    }
}

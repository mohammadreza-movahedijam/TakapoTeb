using MediatR;

namespace Application.Commands.Option;

public sealed record DeleteOptionCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteOptionCommand(in Guid Id)
    {
        this.Id = Id;
    }
}

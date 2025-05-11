using MediatR;

namespace Application.Commands.ProductOption;

public sealed record DeleteProductOptionCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteProductOptionCommand(in Guid Id)
    {
        this.Id = Id;
    }
}

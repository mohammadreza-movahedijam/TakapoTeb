using MediatR;

namespace Application.Commands.Image;

public sealed record DeleteImageCommand:IRequest
{
    public Guid Id { get; set; }
}

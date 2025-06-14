using MediatR;

namespace Application.Queries.Image;

public sealed record GetProductImagesByIdQuery : 
    IRequest<IReadOnlyList<ImageViewModel>>
{
    public Guid ProductId { get; set; }
}

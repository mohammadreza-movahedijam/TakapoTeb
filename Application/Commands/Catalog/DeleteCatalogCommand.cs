using MediatR;

namespace Application.Commands.Catalog;
public sealed record DeleteCatalogCommand : IRequest
{
    public Guid Id { get; set; }
}

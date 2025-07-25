using MediatR;

namespace Application.Commands.Catalog;
public sealed record UpdateCatalogCommand : IRequest
{
    public CatalogDto? Catalog { get; set; }
}

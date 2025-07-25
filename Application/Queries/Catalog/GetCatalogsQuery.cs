using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Catalog;

public sealed record GetCatalogsQuery : IRequest<PaginatedList<CatalogViewModel>>
{
    public IPagination? Pagination { get; set; }
}

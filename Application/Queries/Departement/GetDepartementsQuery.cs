using Application.Common;
using Application.Contract;
using MediatR;

namespace Application.Queries.Departement;

public sealed record GetDepartementsQuery : IRequest<PaginatedList<DepartementViewModel>>
{
    public IPagination? Pagination { get; set; }
}

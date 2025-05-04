using Application.Common;
using Application.Contract;
using Application.Queries.User.ViewModel;
using MediatR;

namespace Application.Queries.User;

public sealed record GetUsersQuery : IRequest<PaginatedList<UserViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetUsersQuery(IPagination Pagination)
    {
        this.Pagination = Pagination;
    }
}

using Application.Common;
using Application.Common.Extension;
using Application.Queries.Role.ViewModel;
using Application.Queries.User.ViewModel;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.User;

internal sealed class GetUsersHandler :
    IRequestHandler<GetUsersQuery, PaginatedList<UserViewModel>>
{
    readonly UserManager<UserEntity> _userManager;
    public GetUsersHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    public async Task<PaginatedList<UserViewModel>>
        Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _userManager.Users.AsQueryable();

        PaginatedList<UserViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w =>
                 w.FirstName!.Contains(request!.Pagination!.keyword) ||
                 w.LastName!.Contains(request!.Pagination!.keyword) ||
                 w.PhoneNumber!.Contains(request!.Pagination!.keyword) ||
                 w.UserName!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<UserEntity, UserViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

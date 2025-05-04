using Application.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Role;

internal sealed class GetRoleItemHandler :
    IRequestHandler<GetRoleItemQuery, List<ItemGeneric<string, string>>>
{
    readonly RoleManager<RoleEntity> _roleManager;
    public GetRoleItemHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task<List<ItemGeneric<string, string>>> Handle(GetRoleItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<RoleEntity> query =  _roleManager.Roles.AsQueryable();
        return await query.Select(s => new ItemGeneric<string, string>()
        {
            Id = s.Name,
            Title = s.PersianName
        }).ToListAsync();
    }
}

using Application.Common;
using Application.Common.Extension;
using Application.Queries.Role.ViewModel;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

internal sealed class GetRolesHandler : IRequestHandler<GetRolesQuery, PaginatedList<RoleViewModel>>
{
    readonly RoleManager<RoleEntity> _roleManager;

    public GetRolesHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager= roleManager;
    }
    public async Task<PaginatedList<RoleViewModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();

        PaginatedList<RoleViewModel> model = new();
        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.PersianName!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<RoleEntity, RoleViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}

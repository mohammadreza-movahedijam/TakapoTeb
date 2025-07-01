using Application.Common.Resource;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Commands.Role;

internal sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand>
{
    readonly RoleManager<RoleEntity> _roleManager;
    public UpdateRoleHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();
        RoleEntity? role =
            await _roleManager.Roles.SingleOrDefaultAsync(s => s.Id == request.Role.Id, cancellationToken);

        if (role is null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        role.PersianName = request.Role.PersianName;
        role.Name = request.Role.Name;
        role.IsDefault = request.Role.IsDefault;
        if (request.Role.IsDefault)
        {
            query.ExecuteUpdate(p => p.SetProperty(p => p.IsDefault, false));
        }
        await _roleManager.UpdateAsync(role);
    }
}

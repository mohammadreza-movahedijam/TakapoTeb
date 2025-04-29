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
        RoleEntity? role =
            await _roleManager.Roles.SingleOrDefaultAsync(s => s.Id == request.Role.Id, cancellationToken);

        if (role is null)
        {
            throw new NullReferenceException(Message.NotFoundOnDb);
        }
        role.PersianName = request.Role.PersianName;
        role.Name = request.Role.Name;
        await _roleManager.UpdateAsync(role);
    }
}

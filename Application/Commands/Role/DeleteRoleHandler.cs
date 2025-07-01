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

internal sealed class DeleteRoleHandler :
    IRequestHandler<DeleteRoleCommand>
{
    readonly RoleManager<RoleEntity> _roleManager;
    public DeleteRoleHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        RoleEntity? role =
            await _roleManager.Roles.SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        role.IsDeleted = true;
        await _roleManager.UpdateAsync(role);
    }
}

using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role;

internal sealed class InsertRoleHandler : IRequestHandler<InsertRoleCommand>
{
    readonly RoleManager<RoleEntity> _roleManager;
    public InsertRoleHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task Handle(InsertRoleCommand request, CancellationToken cancellationToken)
    {
        RoleEntity role = new()
        {
            Name=request.Role.Name,
            PersianName=request.Role.PersianName
        };
        await _roleManager.CreateAsync(role);
    }
}

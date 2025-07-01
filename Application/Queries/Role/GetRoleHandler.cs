using Application.Commands.Role.DataTransferObject;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

internal sealed class GetRoleHandler : IRequestHandler<GetRoleQuery, RoleDto>
{
    readonly RoleManager<RoleEntity> _roleManager;
    
    public GetRoleHandler(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;   
    }
    public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        RoleEntity? role=
            await _roleManager.Roles.SingleOrDefaultAsync(s=>s.Id == request.Id,cancellationToken);

        if(role == null)
        {
            throw new NullReferenceException(   CustomMessage.NotFoundOnDb);
        }
        RoleDto roleDto = new()
        {
            Id = role.Id,
            Name = role.Name,
            PersianName = role.PersianName
        };
        return roleDto;
    }
}

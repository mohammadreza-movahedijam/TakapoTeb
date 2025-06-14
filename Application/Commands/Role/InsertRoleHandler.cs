using Application.Common.CustomException;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polly;
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
        IQueryable<RoleEntity> query=_roleManager.Roles.AsQueryable();
      
        RoleEntity role = new()
        {
            Name = request.Role.Name,
            PersianName = request.Role.PersianName,
            IsDefault = request.Role.IsDefault
        };

        if (request.Role.IsDefault) {
            query.ExecuteUpdate(p => p.SetProperty(p => p.IsDefault, false));
        }


        IdentityResult createRoleResult = await _roleManager.CreateAsync(role);
        if (createRoleResult.Succeeded is false)
        {
            StringBuilder errors = new();
            foreach (IdentityError error in createRoleResult.Errors)
            {
                errors.AppendLine(error.Description+"\n");
            }
            throw new InternalException(errors.ToString());
        }
    }
}

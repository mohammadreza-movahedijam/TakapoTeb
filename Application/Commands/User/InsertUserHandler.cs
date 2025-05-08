using Application.Common.CustomException;
using Application.Contract;
using Domain.Entities.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User;

internal sealed class InsertUserHandler :
    IRequestHandler<InsertUserCommand>
{
    readonly RoleManager<RoleEntity> _roleManager;
    readonly IContext _context;
    readonly UserManager<UserEntity> _userManager;
    public InsertUserHandler(UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager
        , IContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }
    public async Task Handle(InsertUserCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            IExecutionStrategy strategy = _context.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>

            {
                using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
                {
                    try
                    {
                        UserEntity user = request.User.Adapt<UserEntity>();

                        IdentityResult insertUserResult =
                            await _userManager.CreateAsync(user);
                        if (insertUserResult.Succeeded is false)
                        {
                            StringBuilder message = new();
                            foreach (IdentityError item in insertUserResult.Errors)
                            {
                                message.AppendLine(item.Description + "\n");
                            }
                            throw new InternalException(message.ToString());
                        }



                        IdentityResult insertRoleResult =
                            await _userManager.AddToRoleAsync(user, request.User.Role!);

                        if (insertRoleResult.Succeeded is false)
                        {
                            await transaction.RollbackAsync();
                            StringBuilder message = new();
                            foreach (IdentityError item in insertRoleResult.Errors)
                            {
                                message.AppendLine(item.Description + "\n");
                            }
                            throw new InternalException(message.ToString());
                        }



                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

            });
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
using Application.Common.CustomException;
using Application.Contract;
using Domain.Entities.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace Application.Commands.User;

internal sealed class UpdateUserHandler :
    IRequestHandler<UpdateUserCommand>
{
    readonly RoleManager<RoleEntity> _roleManager;
    readonly IContext _context;
    readonly UserManager<UserEntity> _userManager;
    public UpdateUserHandler(UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager
        , IContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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
                        UserEntity? user = await _userManager.Users
                            .FirstOrDefaultAsync(f => f.Id == request.User.Id, cancellationToken);

                        if (user == null)
                        {
                            throw new InternalException(Message.NotFoundOnDb, 404);
                        }
                        request.User.Adapt(user);


                        IdentityResult updateUserResult =
                            await _userManager.CreateAsync(user);
                        if (updateUserResult.Succeeded is false)
                        {
                            StringBuilder message = new();
                            foreach (IdentityError item in updateUserResult.Errors)
                            {
                                message.AppendLine(item.Description + "/");
                            }
                            throw new InternalException(message.ToString(), 400);
                        }



                        IList<string> oldRoles = await _userManager.GetRolesAsync(user);
                        if (!oldRoles.Any())
                        {
                            await transaction.RollbackAsync();
                            throw new InternalException(Message.InternalError, 500);
                        }

                        IdentityResult removeOldRoles = await _userManager.RemoveFromRolesAsync(user, oldRoles);

                        if (removeOldRoles.Succeeded is false)
                        {
                            await transaction.RollbackAsync();
                            StringBuilder message = new();
                            foreach (IdentityError item in removeOldRoles.Errors)
                            {
                                message.AppendLine(item.Description + "/");
                            }
                            throw new InternalException(message.ToString(), 400);
                        }

                        IdentityResult insertRoleResult =
                            await _userManager.AddToRoleAsync(user, request.User.Role!);

                        if (insertRoleResult.Succeeded is false)
                        {
                            await transaction.RollbackAsync();
                            StringBuilder message = new();
                            foreach (IdentityError item in insertRoleResult.Errors)
                            {
                                message.AppendLine(item.Description + "/");
                            }
                            throw new InternalException(message.ToString(), 400);
                        }


                        if (!string.IsNullOrEmpty(request.User.Password))
                        {

                            StringBuilder textError = new StringBuilder();
                            IdentityResult resultRemoveOldUserPassword = await _userManager.RemovePasswordAsync(user);
                            if (!resultRemoveOldUserPassword.Succeeded)
                            {
                                await transaction.RollbackAsync();

                                foreach (var error in resultRemoveOldUserPassword.Errors)
                                {
                                    textError.AppendLine(error.Description);
                                }
                                throw new InternalException(textError.ToString(), 400);
                            }







                            IdentityResult insertPasswordResult =
                            await _userManager.AddPasswordAsync(user, request.User.Password!);
                            if (insertPasswordResult.Succeeded is false)
                            {
                                await transaction.RollbackAsync();
                                StringBuilder message = new();
                                foreach (IdentityError item in insertPasswordResult.Errors)
                                {
                                    message.AppendLine(item.Description + "/");
                                }
                                throw new InternalException(message.ToString(), 400);
                            }

                        }



                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
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
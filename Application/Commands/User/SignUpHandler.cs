using Application.Common;
using Application.Contract;
using Domain.Entities.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace Application.Commands.User;

internal sealed class SignUpHandler : IRequestHandler<SignUpCommand, BaseResult>
{
    readonly SignInManager<UserEntity> _signInManager;
    readonly RoleManager<RoleEntity> _roleManager;
    readonly UserManager<UserEntity> _userManager;
    readonly IContext _context;
    public SignUpHandler(UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager,
        SignInManager<UserEntity> signInManager,
        IContext context)
    {
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
        _userManager = userManager;
    }
    public async Task<BaseResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        IExecutionStrategy Strategy = _context.CreateExecutionStrategy();

        return await Strategy.ExecuteAsync(async () =>
        {
            StringBuilder textError = new StringBuilder();
            UserEntity user = request.SignUp.Adapt<UserEntity>();
            using (var transaction = await _context.BeginTransactionAsync())
            {
                var resultInsertUser = await _userManager.CreateAsync(user);
                if (!resultInsertUser.Succeeded)
                {
                    foreach (var error in resultInsertUser.Errors)
                    {
                        textError.AppendLine(error.Description);
                    }
                    return BaseResult.Fail(textError.ToString());
                }

                RoleEntity? role = await _roleManager.Roles.
                FirstOrDefaultAsync(f => f.IsDefault == true, cancellationToken);
                if (role == null)
                {
                    return BaseResult.Fail();
                }
                var resultInserUserRole = await _userManager.AddToRoleAsync(user, role.Name!);
                if (!resultInserUserRole.Succeeded)
                {
                    foreach (var error in resultInserUserRole.Errors)
                    {
                        textError.AppendLine(error.Description);
                    }
                    await transaction.RollbackAsync();
                    return BaseResult.Fail(textError.ToString());
                }
                var resultInserUserPassword = await _userManager
                .AddPasswordAsync(user, request.SignUp!.Password!);
                if (!resultInserUserPassword.Succeeded)
                {
                    foreach (var error in resultInserUserPassword.Errors)
                    {
                        textError.AppendLine(error.Description);
                    }
                    await transaction.RollbackAsync();
                    return BaseResult.Fail(textError.ToString());
                }
                await transaction.CommitAsync();
                await _signInManager.SignInAsync(user,false);
                return BaseResult.Success();
            }
        });
    }
}

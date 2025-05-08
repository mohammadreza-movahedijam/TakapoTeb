using Application.Common.CustomException;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Commands.User;

internal sealed class SetPasswordHandler
    : IRequestHandler<SetPasswordCommand>
{
    readonly UserManager<UserEntity> _userManager;
    public SetPasswordHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    public async Task Handle(SetPasswordCommand request, CancellationToken cancellationToken)
    {
        UserEntity? user = await _userManager.Users
                           .FirstOrDefaultAsync(f => f.Id == request.UserId,
                           cancellationToken);
        if (user == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }

        bool ExistPassword = await _userManager.HasPasswordAsync(user);
        if (ExistPassword)
        {
            StringBuilder textError = new StringBuilder();
            IdentityResult resultRemoveOldUserPassword =
            await _userManager.RemovePasswordAsync(user);
            if (!resultRemoveOldUserPassword.Succeeded)
            {
                foreach (var error in resultRemoveOldUserPassword.Errors)
                {
                    textError.AppendLine(error.Description);
                }
                throw new InternalException(textError.ToString());
            }
        }

        IdentityResult insertPasswordResult =
        await _userManager.AddPasswordAsync(user, request.Password!);
        if (insertPasswordResult.Succeeded is false)
        {
            StringBuilder message = new();
            foreach (IdentityError item in insertPasswordResult.Errors)
            {
                message.AppendLine(item.Description + "/");
            }
            throw new InternalException(message.ToString(), 400);
        }
    }
}

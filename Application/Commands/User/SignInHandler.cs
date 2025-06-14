using Application.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Application.Commands.User;

internal sealed class SignInHandler :
    IRequestHandler<SignInCommand, BaseResult>
{
    readonly SignInManager<UserEntity> _signInManager;
    readonly UserManager<UserEntity> _userManager;
    public SignInHandler(UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager
        )
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task<BaseResult> Handle(SignInCommand request,
        CancellationToken cancellationToken)
    {
        string message = string.Empty;
        UserEntity? user = await _userManager.Users.
            FirstOrDefaultAsync(f => f.UserName == request.SignIn!.UserName, cancellationToken);
        if (user == null)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {
                message = "The username or password is incorrect";
            }
            else
            {
                message = "نام کاربری یا رمز عبور اشتباه است";
            }
            return BaseResult.Fail(message);
        }
        bool checkPassword = await _userManager.CheckPasswordAsync(user!, request.SignIn!.Password!);
        if (checkPassword is false)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {
                message = "The username or password is incorrect";
            }
            else
            {
                message = "نام کاربری یا رمز عبور اشتباه است";
            }
            return BaseResult.Fail(message);
        }
        bool canSignIn = await _signInManager.CanSignInAsync(user!);
        if (!canSignIn)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {
                message = "You are not authorized to enter";
            }
            else
            {
                message = "شما مجاز به ورود نیستید";
            }
            return BaseResult.Fail(message);
        }
        await _signInManager.SignInAsync(user!, false);
        return BaseResult.Success();
    }
}

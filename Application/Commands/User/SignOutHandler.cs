using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User;

internal sealed class SignOutHandler :
    IRequestHandler<SignOutCommand>
{
    readonly SignInManager<UserEntity> _signInManager;
    public SignOutHandler(SignInManager<UserEntity> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}

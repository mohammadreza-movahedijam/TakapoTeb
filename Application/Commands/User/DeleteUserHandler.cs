using Application.Common.CustomException;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.User;


internal sealed class DeleteUserHandler :
    IRequestHandler<DeleteUserCommand>
{
    readonly UserManager<UserEntity> _userManager;
    public DeleteUserHandler(UserManager<UserEntity> userManager)
    {
        this._userManager = userManager;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        UserEntity? user = await _userManager
            .Users.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb, 404);
        }
        user.IsDeleted = true;
        await _userManager.UpdateAsync(user);
    }
}

using Application.Commands.User.DataTransferObject;
using Application.Common.CustomException;
using Application.Common.Extension;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.User;

internal sealed class GetUserHandler :
    IRequestHandler<GetUserQuery, UserDto>
{
    readonly UserManager<UserEntity> _userManager;
    public GetUserHandler(UserManager<UserEntity> userManager)
    {
        this._userManager = userManager;
    }
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<UserEntity,UserDto>()
            .Map(d=>d.FirstName,s=>s.FirstName)
            .Map(d=>d.LastName,s=>s.LastName)
            .Map(d=>d.Id,s=>s.Id)
            .Map(d=>d.UserName,s=>s.UserName)
            .Map(d=>d.Email,s=>s.Email)
            .Map(d=>d.PhoneNumber,s=>s.PhoneNumber).Compile();
        UserDto userDto = new();
        UserEntity? User =await _userManager.Users.FirstOrDefaultAsync(f=>f.Id == request.Id,cancellationToken);
        if (User == null) 
        {
            throw new InternalException(Message.NotFoundOnDb, 404);
        }
        userDto =User.Adapt<UserDto>(config);
        var roles=(List<string>)await _userManager.GetRolesAsync(User);
        userDto.Role = roles.FirstOrDefault();
        return userDto;
    }
}

using Application.Common;
using Application.Contract;
using Application.Queries.Role.ViewModel;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;

namespace Application.Commands.User;

internal sealed class SignInHandler :
    IRequestHandler<SignInCommand, BaseResult>
{
    readonly IRepository<RoleRouteEntity> _roleRouteRepository;
    readonly SignInManager<UserEntity> _signInManager;
    readonly UserManager<UserEntity> _userManager;
    public SignInHandler(UserManager<UserEntity> userManager,
        IRepository<RoleRouteEntity> roleRouteRepository,
        SignInManager<UserEntity> signInManager
        )
    {
        _roleRouteRepository = roleRouteRepository;
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
        var role = await _userManager.GetRolesAsync(user);

        var query = _roleRouteRepository.GetByQuery();
        var routes = await query.Include(i => i.Route).Where(i => role.Contains(i.Role.Name))
            .ToListAsync();


        if (routes != null)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var oldClaims = userClaims.ToList();
            if (oldClaims != null) {
            await _userManager.RemoveClaimsAsync(user, oldClaims!);
            }
            List<RouteViewModel> routesViewModel = [];
            foreach (var route in routes)
            {
                RouteViewModel routeView = new()
                {
                    Icon = route.Route!.Icon,
                    Id = route.Route.Id,
                    Title = route.Route.Title,
                    Order=route.Route.Order,
                    Url = route.Route.Url
                };
                routesViewModel.Add(routeView);
            }
            Claim roleClaim = new Claim("Role", role.FirstOrDefault());
            Claim routeClaim = new Claim("Route", JsonConvert.SerializeObject(routesViewModel));
           List<Claim> claims = new List<Claim>();  
            claims.Add(routeClaim); 
            claims.Add(roleClaim); 

            await _userManager.AddClaimsAsync(user, claims);
        }




        await _signInManager.SignInAsync(user!, false);
        return BaseResult.Success();
    }
}

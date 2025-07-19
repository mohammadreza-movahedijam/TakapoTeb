using Application.Queries.Role.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NuGet.Configuration;

namespace EndPointUI.Areas.Admin;

public class AdminAuthorize : Attribute, IAuthorizationFilter
{

    private readonly string _groupName;

    public AdminAuthorize(string groupName)
    {
        _groupName = groupName;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity!.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if(context.HttpContext.Request.Path!="/Admin" && context.HttpContext.Request.Path != "/Admin/Dashboard")
        {
            var claim = context.HttpContext.User.Claims.Where(w => w.Type == "Route").FirstOrDefault();
            if (claim != null)
            {
                List<RouteViewModel>? routes =
                JsonConvert.DeserializeObject<List<RouteViewModel>>(claim.Value);

                if (!routes!.Any(a => a.Url.Contains(_groupName)))
                {
                    context.HttpContext.Response.Redirect("/Forbidden");
                  
                    return;
                }
            }

        }




    }
}

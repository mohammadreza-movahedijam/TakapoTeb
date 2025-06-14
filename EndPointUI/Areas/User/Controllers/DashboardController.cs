using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EndPointUI.Areas.User.Controllers;
[Area("User")]
[Authorize]
public class DashboardController : Controller
{
    public IActionResult MyProfile()
    {
        return View();
    }
}

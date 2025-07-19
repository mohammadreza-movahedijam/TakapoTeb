using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Dashboard")]
public class DashboardController : Controller
{
    [Route("/Admin")]
    [Route("/Admin/Dashboard")]
    public IActionResult Index()
    {
        return View();
    }
}

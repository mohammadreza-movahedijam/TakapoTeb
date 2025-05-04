using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;



namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

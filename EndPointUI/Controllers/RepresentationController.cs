using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class RepresentationController : Controller
{
    [Route("/Hologic")]
    public IActionResult Hologic()
    {
        return View();
    }

    [Route("/BD")]
    public IActionResult BD()
    {
        return View();
    }

    [Route("/Mindray")]
    public IActionResult Mindray()
    {
        return View();
    }
    [Route("/Snibe")]
    public IActionResult Snibe()
    {
        return View();
    }


}

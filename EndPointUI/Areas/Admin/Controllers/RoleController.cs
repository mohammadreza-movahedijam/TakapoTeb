using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
public class RoleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Delete([FromBody]Input model)
    {
        return Ok(model);
    }
}
public class Input
{
    public int Id { get; set; }
}
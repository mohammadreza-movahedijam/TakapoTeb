using Application.Commands.Setting;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
public class SettingController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    [HttpGet]
    public async Task<IActionResult> General()
    {
        SettingDto Setting = await _mediator.Send(new GetSettingQuery());
        return View(Setting);
    }
    [HttpPost]
    public async Task<IActionResult> General(SettingDto Setting)
    {
      await  _mediator.Send(new ChangeSettingCommand(Setting));
        return RedirectToAction("General");
    }
}

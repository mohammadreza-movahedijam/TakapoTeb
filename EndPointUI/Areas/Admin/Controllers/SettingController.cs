using Application.Commands.Feature;
using Application.Commands.Setting;
using Application.Commands.Statistic;
using Application.Queries.Feature;
using Application.Queries.Setting;
using Application.Queries.Statistic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[AdminAuthorize("Setting")]
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

    [HttpGet]
    public async Task<IActionResult> Feature()
    {
        FeatureDto feature=await _mediator.Send(new GetFeatureQuery()); 
        return View(feature);
    }
    [HttpPost]
    public async Task<IActionResult> Feature(FeatureDto Feature)
    {
        await _mediator.Send(new ChangeFeatureCommand()
        {
            Feature=Feature
        });
        return RedirectToAction("Feature");
    }
     [HttpGet]
    public async Task<IActionResult> Statistic()
    {
        StatisticDto Statistic = await _mediator.Send(new GetStatisticQuery()); 
        return View(Statistic);
    }
    [HttpPost]
    public async Task<IActionResult> Statistic(StatisticDto Statistic)
    {
        await _mediator.Send(new ChangeStatisticCommand()
        {
            Statistic = Statistic
        });
        return RedirectToAction("Statistic");
    }

}

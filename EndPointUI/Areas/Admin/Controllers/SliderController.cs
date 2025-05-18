using Application.Commands.Slider;
using Application.Queries.Slider;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<SliderViewModel> pageModel =
            await _mediator.Send(new GetSlidersQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderDto Slider)
    {
        await _mediator.Send(new InsertSliderCommand(Slider));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        SliderDto Slider = await _mediator.Send(new GetSliderQuery(Id));
        return View(Slider);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(SliderDto Slider)
    {
        await _mediator.Send(new UpdateSliderCommand(Slider));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteSliderCommand(input.Id));
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                ex.Message,
            });
        }
    }

}

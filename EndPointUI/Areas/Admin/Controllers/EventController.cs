using Application.Commands.Event;
using Application.Queries.Event;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Event")]
public class EventController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<EventViewModel> pageModel =
            await _mediator.Send(new GetEventsQuery()
            {
                Pagination= pagination
            });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventDto Event)
    {
        await _mediator.Send(new InsertEventCommand()
        {
            Event= Event
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        EventDto Event = await _mediator.Send(new GetEventQuery()
        {
            Id= Id
        });
        return View(Event);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EventDto Event)
    {
        await _mediator.Send(new UpdateEventCommand()
        {
            Event= Event
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteEventCommand()
            {
                Id= input.Id
            });
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

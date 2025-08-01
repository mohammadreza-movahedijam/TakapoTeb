using Application.Commands.Picture;
using Application.Queries.Picture;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Picture")]
public class PictureController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination, Guid EventId)
    {
        ViewBag.EventId = EventId;
        PaginatedList<PictureViewModel> pageModel =
            await _mediator.Send(new GetPicturesQuery()
            {
                Pagination = pagination,
                EventId=EventId
            });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create(Guid EventId)
    {
        ViewBag.EventId = EventId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PictureDto Picture)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.EventId = Picture.EventId;

            return View(Picture);
        }
        await _mediator.Send(new InsertPictureCommand()
        {
            Picture = Picture
        });
        return RedirectToAction(nameof(Index), new { EventId = Picture.EventId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        PictureDto Picture = await _mediator.Send(new GetPictureQuery()
        {
            Id = Id
        });
        return View(Picture);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(PictureDto Picture)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.EventId = Picture.EventId;

            return View(Picture);
        }
        await _mediator.Send(new UpdatePictureCommand()
        {
            Picture = Picture
        });
        return RedirectToAction(nameof(Index), new { EventId = Picture.EventId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeletePictureCommand()
            {
                Id = input.Id
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
                Message = ex.Message,
            });
        }
    }
}

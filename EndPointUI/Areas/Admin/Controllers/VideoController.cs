using Application.Commands.Video;
using Application.Queries.Video;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Video")]
public class VideoController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination, Guid EventId)
    {
        ViewBag.EventId = EventId;
        PaginatedList<VideoViewModel> pageModel =
            await _mediator.Send(new GetVideosQuery(EventId, pagination));
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
    public async Task<IActionResult> Create(VideoDto Video)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.EventId = Video.EventId;

            return View(Video);
        }
        await _mediator.Send(new InsertVideoCommand()
        {
            Video = Video
        });
        return RedirectToAction(nameof(Index), new { EventId = Video.EventId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        VideoDto Video = await _mediator.Send(new GetVideoQuery()
        {
            Id = Id
        });
        return View(Video);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(VideoDto Video)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.EventId = Video.EventId;

            return View(Video);
        }
        await _mediator.Send(new UpdateVideoCommand()
        {
            Video = Video
        });
        return RedirectToAction(nameof(Index), new { EventId = Video.EventId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteVideoCommand()
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

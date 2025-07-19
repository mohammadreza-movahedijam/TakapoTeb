using Application.Commands.Feedback;
using Application.Queries.Feedback;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Feedback")]
public class FeedbackController(IMediator mediator) : Controller
{
    readonly IMediator _mediator=mediator;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<FeedbackViewModel> pageModel =
            await _mediator.Send(new GetFeedbacksQuery()
            {
                Pagination = pagination
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
    public async Task<IActionResult> Create(FeedbackDto Feedback)
    {
        await _mediator.Send(new InsertFeedbackCommand()
        {
            Feedback = Feedback
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        FeedbackDto Feedback = await _mediator.Send
            (new GetFeedbackQuery()
            {
                Id = Id
            });
        return View(Feedback);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(FeedbackDto Feedback)
    {
        await _mediator.Send(new UpdateFeedbackCommand()
        {
            Feedback = Feedback
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteFeedbackCommand()
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
                ex.Message,
            });
        }
    }







}

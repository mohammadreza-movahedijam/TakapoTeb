using Application.Commands.Page;
using Application.Queries.Page;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;


[Area("Admin")]
[AdminAuthorize("Page")]
public class PageController (IMediator mediator): Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<PageViewModel> pageModel =
            await _mediator.Send(new GetPagesQuery()
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
    public async Task<IActionResult> Create(PageDto Page)
    {
        await _mediator.Send(new InsertPageCommand()
        {
            Page = Page
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        PageDto Page = await _mediator.Send
            (new GetPageQuery()
            {
                Id = Id
            });
        return View(Page);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(PageDto Page)
    {
        await _mediator.Send(new UpdatePageCommand()
        {
            Page = Page
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeletePageCommand()
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

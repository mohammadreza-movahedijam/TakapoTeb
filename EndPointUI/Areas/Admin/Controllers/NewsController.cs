using Application.Commands.News;
using Application.Queries.BlogCategory;
using Application.Queries.News;
using Application.Queries.NewsCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("News")]
public class NewsController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<NewsViewModel> pageModel =
            await _mediator.Send(new GetNewsQuery()
            {
                Pagination = pagination
            });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await FetchCategory();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewsDto News)
    {
      
        await _mediator.Send(new InsertNewsCommand()
        {
            News = News
        });
        return Redirect("/Admin/News");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        await FetchCategory();
        NewsDto News = await _mediator.Send
            (new GetNewsByIdQuery()
            {
                Id = Id
            });
        return View(News);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(NewsDto News)
    {
        await _mediator.Send(new UpdateNewsCommand()
        {
            News = News
        });
        return Redirect("/Admin/News");
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteNewsCommand()
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

    async Task FetchCategory()
    {
        var items = await _mediator.Send(new GetNewsCategoryItemQuery());
        ViewBag.Categories = new SelectList(items, "Id", "Title");
    }


}

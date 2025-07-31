using Application.Commands.NewsCategory;
using Application.Queries.NewsCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;


[Area("Admin")]
[AdminAuthorize("NewsCategory")]
public class NewsCategoryController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<NewsCategoryViewModel> pageModel =
            await _mediator.Send(new GetNewsCategoriesQuery()
            {
                Pagination = pagination,
            });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewsCategoryDto NewsCategory)
    {
        await _mediator.Send(new InsertNewsCategoryCommand()
        {
            NewsCategory = NewsCategory
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        NewsCategoryDto NewsCategory = await _mediator.Send(new GetNewsCategoryQuery()
        {
            Id = Id
        });
        return View(NewsCategory);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(NewsCategoryDto NewsCategory)
    {
        await _mediator.Send(new UpdateNewsCategoryCommand()
        {
            NewsCategory = NewsCategory
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteNewsCategoryCommand()
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

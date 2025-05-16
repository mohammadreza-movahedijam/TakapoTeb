using Application.Commands.BlogCategory;
using Application.Queries.BlogCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class BlogCategoryController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<BlogCategoryViewModel> pageModel =
            await _mediator.Send(new GetBlogCategoriesQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
       
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogCategoryDto BlogCategory)
    {
        await _mediator.Send(new InsertBlogCategoryCommand(BlogCategory));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        
        BlogCategoryDto BlogCategory = await _mediator.Send(new GetBlogCategoryQuery(Id));
        return View(BlogCategory);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(BlogCategoryDto BlogCategory)
    {
        await _mediator.Send(new UpdateBlogCategoryCommand(BlogCategory));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteBlogCategoryCommand(input.Id));
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

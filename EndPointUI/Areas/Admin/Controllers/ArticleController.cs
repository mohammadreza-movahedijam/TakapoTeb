using Application.Commands.Article;
using Application.Queries.Article;
using Application.Queries.Article.ViewModels;
using Application.Queries.BlogCategory;
using Application.Queries.ProductCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Article")]
public class ArticleController (IMediator mediator): Controller
{
     readonly IMediator _mediator=mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<ArticleViewModel> pageModel =
            await _mediator.Send(new GetArticlesQuery(pagination));
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
    public async Task<IActionResult> Create(ArticleDto Article)
    {
        await _mediator.Send(new InsertArticleCommand(Article));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        await FetchCategory();
        ArticleDto Article = await _mediator.Send(new GetArticleQuery(Id));
        return View(Article);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ArticleDto Article)
    {
        await _mediator.Send(new UpdateArticleCommand(Article));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteArticleCommand(input.Id));
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

     async Task FetchCategory()
    {
        var items = await _mediator.Send(new GetBlogCategoryItemQuery());
        ViewBag.Categories = new SelectList(items, "Id", "Title");
    }

}

using Application.Queries.Article;
using Application.Queries.Article.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class BlogController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;

    [HttpGet]
    [Route("Blog")]
    public async Task<IActionResult> Index
        (Pagination pagination,Guid CategoryId)
    {
        PaginatedList<ArticleViewModel> pageModel=
            await _mediator.Send(new GetArticlesQuery(pagination)
            {
                CategoryId = CategoryId
            });
        ViewBag.CategoryId = CategoryId;
        return View(pageModel);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid Id)
    {
        ArticleDetailViewModel model =
            await _mediator.Send(new GetArticleDetailQuery()
            {
                Id = Id
            });
        return View(model);
    }
}

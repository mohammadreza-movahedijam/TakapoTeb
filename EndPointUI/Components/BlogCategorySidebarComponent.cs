using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.BlogCategory;

namespace EndPointUI.Components;

public class BlogCategorySidebarComponent(IMediator mediator)
    :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<BlogCategoryViewModel> model =
            await _mediator.Send(new GetBlogCategoryWithCountArticleQuery());
        return View("/Views/Shared/ViewComponent/BlogCategorySidebarComponent.cshtml", model);
    }
}

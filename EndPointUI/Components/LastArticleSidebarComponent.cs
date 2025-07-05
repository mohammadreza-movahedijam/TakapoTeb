using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class LastArticleSidebarComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<ArticleViewModel> model =
            await _mediator.Send(new GetLastArticleQuery());
        return View("/Views/Shared/ViewComponent/LastArticleSidebarComponent.cshtml", model);
    }
}

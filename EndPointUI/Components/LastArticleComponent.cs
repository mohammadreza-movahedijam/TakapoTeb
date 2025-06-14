using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
namespace EndPointUI.Components;

public class LastArticleComponent(IMediator mediator) :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<ArticleViewModel> model =
            await _mediator.Send(new GetLastArticleQuery());
        return View("/Views/Shared/ViewComponent/LastArticleComponent.cshtml", model);
    }
}

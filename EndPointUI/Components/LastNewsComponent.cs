using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.News;

namespace EndPointUI.Components;

public class LastNewsComponent(IMediator mediator):ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<NewsViewModel> model =
            await _mediator.Send(new GetLastNewsQuery());
        return View("/Views/Shared/ViewComponent/LastNewsComponent.cshtml", model);
    }
}

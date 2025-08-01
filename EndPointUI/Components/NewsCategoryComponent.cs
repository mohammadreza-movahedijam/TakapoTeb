using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.NewsCategory;

namespace EndPointUI.Components;

public class NewsCategoryComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<NewsCategoryViewModel> model =
            await _mediator.Send(new GetNewsCategoriesTabQuery());
        return View("/Views/Shared/ViewComponent/NewsCategoryComponent.cshtml", model);
    }
}

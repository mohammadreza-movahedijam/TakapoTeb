using Application.Queries.Article;
using Application.Queries.Setting.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class IntroductionComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IntroductionVieModel model =
            await _mediator.Send(new GetIntroductionQuery());
        return View("/Views/Shared/ViewComponent/IntroductionComponent.cshtml",
            model);
    }
}

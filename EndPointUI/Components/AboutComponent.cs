using Application.Queries.Setting;
using Application.Queries.Setting.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class AboutComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        AboutSectionViewModel model =
            await _mediator.Send(new GetAboutQuery());
        return View("/Views/Shared/ViewComponent/AboutComponent.cshtml", model);
    }
}

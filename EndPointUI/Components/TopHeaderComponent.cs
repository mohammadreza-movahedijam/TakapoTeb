using Application.Queries.Setting;
using Application.Queries.Setting.ViewModels;
using Application.Queries.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class TopHeaderComponent(IMediator mediator) :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        WayCommunicationViewModel model =
            await _mediator.Send(new GetWayCommunicationQuery());
        return View("/Views/Shared/ViewComponent/TopHeaderComponent.cshtml", model);
    }
}

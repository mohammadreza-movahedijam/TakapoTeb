using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EndPointUI.Components;

public class LogoHeaderComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        LogoViewModel model =
            await _mediator.Send(new GetLogoQuery());
        return View("/Views/Shared/ViewComponent/LogoHeaderComponent.cshtml", model);
    }
}

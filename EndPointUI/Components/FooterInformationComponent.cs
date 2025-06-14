using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EndPointUI.Components;

public class FooterInformationComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        FooterInformationViewModel model =
            await _mediator.Send(new GetFooterInformationQuery());
        return View("/Views/Shared/ViewComponent/FooterInformationComponent.cshtml", model);
    }
}

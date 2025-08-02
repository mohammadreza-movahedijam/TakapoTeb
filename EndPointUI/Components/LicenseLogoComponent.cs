using Application.Queries.Setting;
using Application.Queries.Statistic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class LicenseLogoComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string model =
            await _mediator.Send(new GetLicenseLogoQuery());
        return View("/Views/Shared/ViewComponent/LicenseLogoComponent.cshtml", model);
    }
}

using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class AcademyComponent
 (IMediator mediator)
    : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        AcademyViewModel model =
            await _mediator.Send(new GetAcademyQuery());
        return View("/Views/Shared/ViewComponent/AcademyComponent.cshtml", model);
    }
}

using Application.Queries.Departement;
using Application.Queries.Feature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class FeatureComponent(IMediator mediator) :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
       FeatureViewModel model =
           await _mediator.Send(new GetFeatureItemQuery());
        return View("/Views/Shared/ViewComponent/FeatureComponent.cshtml", model);
    }
}

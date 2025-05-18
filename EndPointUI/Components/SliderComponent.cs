using Application.Queries.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class SliderComponent (IMediator mediator): ViewComponent
{
    readonly IMediator _mediator=mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<SliderViewModel> model =await _mediator.Send(new GetHomePageSliderQuery());
        return View("/Views/Shared/ViewComponent/SliderComponent.cshtml", model);
    }
}

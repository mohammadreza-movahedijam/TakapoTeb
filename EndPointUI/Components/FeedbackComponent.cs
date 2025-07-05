using Application.Queries.Feature;
using Application.Queries.Feedback;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class FeedbackComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<FeedbackViewModel> model =
            await _mediator.Send(new GetFeedbackItemQuery());
        return View("/Views/Shared/ViewComponent/FeedbackComponent.cshtml", model);
    }
}

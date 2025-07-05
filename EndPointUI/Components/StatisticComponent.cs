using Application.Commands.Statistic;
using Application.Queries.Statistic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class StatisticComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        StatisticViewModel model =
            await _mediator.Send(new GetStatisticItemQuery());
        return View("/Views/Shared/ViewComponent/StatisticComponent.cshtml", model);
    }
}

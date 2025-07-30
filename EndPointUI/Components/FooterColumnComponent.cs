using Application.Queries.BlogCategory;
using Application.Queries.Setting;
using Application.Queries.Setting.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class FooterColumnComponent
    (IMediator mediator)
    : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        FooterColumnViewModel model =
            await _mediator.Send(new GetFooterColumnQuery());
        return View("/Views/Shared/ViewComponent/FooterColumnComponent.cshtml", model);
    }
}

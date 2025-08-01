using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Page;

namespace EndPointUI.Components;

public class PageComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<PageViewModel> model =
            await _mediator.Send(new GetPageForMenuQuery());
        return View("/Views/Shared/ViewComponent/PageComponent.cshtml", model);
    }
}

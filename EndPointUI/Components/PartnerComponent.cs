using Application.Queries.Article;
using Application.Queries.Partner;
using Application.Queries.Setting.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class PartnerComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<PartnerViewModel> model =
            await _mediator.Send(new GetPartnersWithOutPaginationQuery());
        return View("/Views/Shared/ViewComponent/PartnerComponent.cshtml",
            model);
    }
}
